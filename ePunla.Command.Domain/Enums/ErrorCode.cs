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

        // FARM CROP ERROR
        CropStatusIsNotPlanted = 4001,
        CropNotFound = 4002,

    }
}
