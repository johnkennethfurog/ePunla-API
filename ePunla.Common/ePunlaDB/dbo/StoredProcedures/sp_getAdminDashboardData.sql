CREATE PROCEDURE [dbo].[sp_getAdminDashboardData]
AS
BEGIN

--  FOR NUMBER OF CROPS PER BARANNGAY
  SELECT FC.CropId, B.BarangayId, COUNT(FC.CropId) as 'CropsCount',C.Name as 'Crop', B.Name as 'Barangay',B.Lat,B.Lng FROM FarmCrops FC
  LEFT JOIN Farms F ON F.FarmId = FC.FarmId
  LEFT JOIN Barangays B ON B.BarangayId = F.BarangayId
  LEFT JOIN Crops C ON C.CropId = FC.CropId
  GROUP BY B.BarangayId,FC.CropId, C.Name,B.Name,B.Lat,B.Lng,B.BarangayId

-- FOR NUMBER OF PLANTED, HARVESTED OR DAMAGED CROP PER BARANGAY
SELECT  B.BarangayId, COUNT(FC.[Status]) as 'CropsCount', B.Name as 'Barangay', FC.[Status] FROM FarmCrops FC
LEFT JOIN Farms F ON F.FarmId = FC.FarmId
LEFT JOIN Barangays B ON B.BarangayId = F.BarangayId
GROUP BY B.BarangayId,B.Name, FC.[Status]


-- FOR NUMBER OF FARMER PER BARANGAY
SELECT B.Name as 'Barangay',B.BarangayId, COUNT(F.FarmerId) AS 'FarmerCount'  FROM Farmers F
LEFT JOIN Barangays B ON B.BarangayId = F.BarangayId
GROUP BY B.BarangayId, B.Name

-- FOR NUMBER OF FARMER PER BARANGAY
SELECT 
    F.FirstName, 
    F.LastName, 
    F.StreetAddress, 
    B.Name as 'Barangay', 
    MobileNumber = F.MobileNumber,
    B.BarangayId, 
    F.FarmerId
FROM Farmers F
LEFT JOIN Barangays B ON B.BarangayId = F.BarangayId

DECLARE @ActiveFarmerCount INT;
DECLARE @FarmCount INT;
DECLARE @PlantedCropsSqm INT;
DECLARE @HarvestedCropsSqm INT;
DECLARE @DamagedCropsSqm INT;

SELECT @ActiveFarmerCount = COUNT(FarmerId) FROM Farmers
SELECT @FarmCount = COUNT(*) from Farms
SELECT @PlantedCropsSqm = SUM(AreaSize) FROM FarmCrops WHERE [Status] = 'Planted'
SELECT @HarvestedCropsSqm = SUM(AreaSize) FROM FarmCrops WHERE [Status] = 'Harvested'
SELECT @DamagedCropsSqm = SUM(AreaSize) FROM FarmCrops WHERE [Status] = 'Damaged'

SELECT @FarmCount AS 'FarmCount', @ActiveFarmerCount AS 'ActiveFarmerCount', @PlantedCropsSqm as 'PlantedCropsSqm', @HarvestedCropsSqm as 'HarvestedCropsSqm', @DamagedCropsSqm as 'DamagedCropsSqm'


END