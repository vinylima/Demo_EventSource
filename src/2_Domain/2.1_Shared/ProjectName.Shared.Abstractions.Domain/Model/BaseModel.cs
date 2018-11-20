
using System;

namespace ProjectName.Shared.Abstractions.Domain
{
    public abstract class BaseModel<TModel> : IModel where TModel : IModel
    {
        public Guid Id { get; set; }

        public BaseModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid GetId() => this.Id;

        public abstract void CopyTo(TModel model);

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseModel<TModel>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(BaseModel<TModel> a, BaseModel<TModel> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseModel<TModel> a, BaseModel<TModel> b)
        { return !(a == b); }

        public override int GetHashCode()
        { return (GetType().GetHashCode() * 907) + Id.GetHashCode(); }

    }
}