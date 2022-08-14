SELECT * FROM Tenants as T
WHERE EXISTS (
	SELECT 1 FROM TenantApartments
	INNER JOIN Tenants as TenantsWithApartments ON TenantApartments.TenantId = TenantsWithApartments.TenantId
	WHERE T.TenantId = TenantsWithApartments.TenantId
)