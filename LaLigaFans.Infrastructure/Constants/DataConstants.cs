namespace LaLigaFans.Infrastructure.Constants
{
    public class DataConstants
    {
        //User data constants
        public const int UserFirstNameMaxLength = 50;
        public const int UserFirstNameMinLength = 2;

        public const int UserLastNameMaxLength = 50;
        public const int UserLastNameMinLength = 3;

        //Team data constants
        public const int TeamNameMaxLength = 30;
        public const int TeamNameMinLength = 3;

        public const int TeamLogoUrlMaxLength = 256;
        public const int TeamLogoUrlMinLength = 4;

        public const int TeamFoundedYearMax = 2024;
        public const int TeamFoundedYearMin = 1800;

        public const int TeamCoachNameMaxLength = 50;
        public const int TeamCoachNameMinLength = 3;

        public const int TeamInformationMaxLength = 2048;
        public const int TeamInformationMinLength = 256;

        //Player data constants
        public const int PlayerFirstNameMaxLength = 50;
        public const int PlayerFirstNameMinLength = 2;

        public const int PlayerLastNameMaxLength = 50;
        public const int PlayerLastNameMinLength = 3;

        public const int PlayerImageUrlMaxLength = 256;

        //News data constants
        public const int NewsTitleMaxLength = 100;
        public const int NewsTitleMinLength = 10;

        public const int NewsImageUrlMaxLength = 256;

        public const int NewsContentMaxLength = 4096;
        public const int NewsContentMinLength = 512;

        //Comment data constants
        public const int CommentTitleMaxLength = 20;
        public const int CommentTitleMinLength = 3;

        public const int CommentContentMaxLength = 128;
        public const int CommentContentMinLength = 10;

        //Category data constants
        public const int CategoryNameMaxLength = 15;
        public const int CategoryNameMinLength = 3;

        //Product data constants
        public const int ProductNameMaxLength = 30;
        public const int ProductNameMinLength = 5;

        public const int ProductDescriptionMaxLength = 100;
        public const int ProductDescriptionMinLength = 30;

        public const int ProductImageUrlMaxLength = 256;

        //Address data constants
        public const int AddressCityMaxName = 30;
        public const int AddressCityMinName = 3;

        public const int AddressStreetMaxName = 50;
        public const int AddressStreetMinName = 10;

        //Question data constants
        public const int QuestionTitleMaxLength = 20;
        public const int QuestionTitleMinLength = 5;

        public const int QuestionContentMaxLength = 20;
        public const int QuestionContentMinLength = 5;

    }
}
