using System;

namespace PocInk.Helpers
{
   public static class TypeExtensions
    {
        public static Guid Int2Guid(this int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
