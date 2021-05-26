CREATE PROCEDURE [dbo].[sp_getBarangaysAndAreas]
AS
SELECT 
  B.BarangayId,
  [Barangay]=B.Name,
  BA.BarangayAreaId,
  [Area]=BA.Name FROM Barangays B
LEFT JOIN BarangayAreas BA ON B.BarangayId = BA.BarangayId
WHERE B.IsActive = 1 AND BA.IsActive = 1
