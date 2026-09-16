using AspNetCoreTemplate.Application.Contract.Common.Authorization;
using AspNetCoreTemplate.Domain.Common;
using AspNetCoreTemplate.Domain.Common.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AspNetCoreTemplate.EntityFrameworkCore.EntityFrameworkCore.Interceptors;

public sealed class AuditingSaveChangesInterceptor(
    ICurrentUser currentUser)
    : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        ApplyAuditing(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditing(eventData.Context);

        return base.SavingChangesAsync(
            eventData,
            result,
            cancellationToken);
    }

    private void ApplyAuditing(DbContext? context)
    {
        if (context is null)
        {
            return;
        }

        foreach (var entry in context.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    ApplyCreationAudit(entry);
                    break;

                case EntityState.Modified:
                    ApplyModificationAudit(entry);
                    break;

                case EntityState.Deleted:
                    ApplyDeletionAudit(entry);
                    break;
            }
        }
    }

    private void ApplyCreationAudit(EntityEntry entry)
    {
        if (entry.Entity is IHasCreationTime creationEntity)
        {
            creationEntity.CreationTime = DateTime.UtcNow;
        }

        if (entry.Entity is IHasCreator<string> creatorEntity)
        {
            creatorEntity.CreatorId = GetCurrentUserId();
        }
    }

    private void ApplyModificationAudit(EntityEntry entry)
    {
        if (entry.Entity is IHasModificationTime modificationEntity)
        {
            modificationEntity.LastModificationTime = DateTime.UtcNow;
        }

        if (entry.Entity is IHasModifier<string> modifierEntity)
        {
            modifierEntity.LastModifierId = GetCurrentUserId();
        }
    }

    private void ApplyDeletionAudit(EntityEntry entry)
    {
        if (entry.Entity is not ISoftDelete)
            return;

        // Soft Delete
        entry.Property(nameof(ISoftDelete.IsDeleted)).CurrentValue = true;
        entry.State = EntityState.Modified;

        if (entry.Entity is IHasDeletionTime entity)
            entity.DeletionTime = DateTime.UtcNow;

        if (entry.Entity is IHasDeleter<string> deleter)
            deleter.DeleterId = GetCurrentUserId();
    }

    private string? GetCurrentUserId()
    {
        return currentUser.IsAuthenticated
            ? currentUser.Id
            : null;
    }
}