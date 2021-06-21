CREATE PROCEDURE [dbo].[sp_getBarangaysAndAreas]
AS
SELECT 
  B.BarangayId,
  B.IsActive,
  [Barangay]=B.Name,
  BA.BarangayAreaId,
  [Area]=BA.Name,
  [AreaIsActive] = BA.IsActive
FROM Barangays B
LEFT JOIN BarangayAreas BA ON B.BarangayId = BA.BarangayId
