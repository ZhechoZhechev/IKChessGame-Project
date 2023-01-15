
namespace ChessGame.Common
{
    using System;
    public static class ObjectValidator
    {
        public static void CheckIfObjectIsNull(object obj, string errorMessage = GlobalConstants.StringEmpty)
        {
            if (obj == null)
                throw new NullReferenceException(GlobalErrorMessages.FigureCannotBeNull);
        }
    }
}
