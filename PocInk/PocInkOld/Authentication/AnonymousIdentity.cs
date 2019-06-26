
namespace PocInkOld.Authentication
{
    //Representation for an unauthenticated user
    public class AnonymousIdentity : UserIdentity
    {
        public AnonymousIdentity()
            : base(string.Empty, string.Empty, string.Empty)
        { }
    }
}
