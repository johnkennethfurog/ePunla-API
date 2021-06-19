namespace ePunla.Command.Domain.Enums
{
    public enum ErrorCode
    {
        // BARANGAY ERROR
        BarangayNotFound = 1001,

        // BARANGAY AREA ERROR
        BarangayAreaNotFound = 2001,

        // FARMER ERROR
        MobileNumberAlreadyExist = 3001,
        InvalidMobileNumber = 3002,

        // FARM CROP ERROR
        CropStatusIsNotPlanted = 4001,
        FarmCropNotFound = 4002,
        CropIsAlreadyPlanted = 4003,

        // FARM ERROR
        FarmNotFound = 5001,
        FarmStatusIsNotPending = 5002,

        // CROP ERROR
        CropNotFound = 6001,
        CropAlreadyExist = 6002,
        CropCategoryNotFound = 6003,

        // CLAIM ERROR
        ClaimNotFound = 7001,
        ClaimStatusIsNotPending = 7002,
        ClaimDuplicateDamageType = 7003,
    }
}
