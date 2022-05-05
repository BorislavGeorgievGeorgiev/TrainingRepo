using CookingRecipesSystem.Server.Domain.Exceptions;

namespace CookingRecipesSystem.Server.Domain.Common
{
  public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity
  {
    private const string _InvalidEntityExceptionMessage = "User ID cannot be null !";

    private string _createdBy;
    private string _modifiedBy;

    public string CreatedBy
    {
      get => this._createdBy;
      set => this._createdBy = value ??
        throw new InvalidEntityException(_InvalidEntityExceptionMessage);
    }

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy
    {
      get => this._modifiedBy;
      set => this._modifiedBy = value ??
        throw new InvalidEntityException(_InvalidEntityExceptionMessage);
    }

    public DateTime? ModifiedOn { get; set; }
  }
}
