using CookingRecipesSystem.Server.Domain.Exceptions;

namespace CookingRecipesSystem.Server.Domain.Common
{
  public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity
  {
    private const string InvalidEntityExceptionMessage = "User ID cannot be null !";

    private string createdBy;
    private string modifiedBy;

    public string CreatedBy
    {
      get => this.createdBy;
      set => this.createdBy = value ??
        throw new InvalidEntityException(InvalidEntityExceptionMessage);
    }

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy
    {
      get => this.modifiedBy;
      set => this.modifiedBy = value ??
        throw new InvalidEntityException(InvalidEntityExceptionMessage);
    }

    public DateTime? ModifiedOn { get; set; }
  }
}
