using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class SqlQueries : ISqlQueries
    {
        public Dictionary<string, string> sqlQueries { get; } = new Dictionary<string, string>()
        {
            //Companies Queries
            {"CompaniesInsertAsync",
                @"
                INSERT INTO public.""tblCompanies""
                (
                    ""CompanyName"",
                    ""CompanyNAICS"",
                    ""CompanySIC"",
                    ""EIN"",
                    ""CorporateEmail"",
                    ""CorporatePhone"",
                    ""CompanyCategory"",
                    ""IsSupplier"",
                    ""IsClient"",
                    ""DateCompanyAddedUpdated"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @CompanyName,
                    @CompanyNAICS,
                    @CompanySIC,
                    @EIN,
                    @CorporateEmail,
                    @CorporatePhone,
                    @CompanyCategory,
                    @IsSupplier,
                    @IsClient,
                    @DateCompanyAddedUpdated,
                    @ActiveStatus
                ) RETURNING ""CompaniesID"";
                "
            },
            {"CompaniesUpdateByIdAsync",
                @"
                UPDATE public.""tblCompanies""
                SET
                ""CompanyName""=COALESCE(@CompanyName,""CompanyName""),
                ""CompanyNAICS""=COALESCE(@CompanyNAICS,""CompanyNAICS""),
                ""CompanySIC""=COALESCE(@CompanySIC,""CompanySIC""),
                ""EIN""=COALESCE(@EIN,""EIN""),
                ""CorporateEmail""=COALESCE(@CorporateEmail,""CorporateEmail""),
                ""CorporatePhone""=COALESCE(@CorporatePhone,""CorporatePhone""),
                ""CompanyCategory""=COALESCE(@CompanyCategory,""CompanyCategory""),
                ""IsSupplier""=COALESCE(@IsSupplier,""IsSupplier""),
                ""IsClient""=COALESCE(@IsClient,""IsClient""),
                ""DateCompanyAddedUpdated""=COALESCE(CURRENT_TIMESTAMP,""DateCompanyAddedUpdated""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE ""CompaniesID""=@CompaniesID;
                "
            },
            {"CompaniesDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblCompanies""
                WHERE ""CompaniesID""=@CompaniesID;
                "
            },
            {"CompaniesGetAllAsync",
                @"
                SELECT*
                FROM public.""tblCompanies"";
                "
            },
            {"CompaniesGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblCompanies""
                WHERE ""CompaniesID""=@CompaniesID;
                "
            },
            //CompanyContacts Queries
            {"CompanyContactsInsertAsync",
                @"
                INSERT INTO public.""tblCompanyContacts""
                (
                    ""FirstName"",
                    ""LastName"",
                    ""ContactTitle"",
                    ""ContactPhone"",
                    ""ActiveStatus"",
                    ""fkStoreLocationsID"",
                    ""ContactEmail""
                )
                VALUES
                (
                    @FirstName,
                    @LastName,
                    @ContactTitle,
                    @ContactPhone,
                    @ActiveStatus,
                    @fkStoreLocationsID,
                    @ContactEmail
                )RETURNING ""CompanyContactsID"";
                "
            },
            {"CompanyContactsUpdateByIdAsync",
                @"
                UPDATE public.""tblCompanyContacts""
                SET
                ""FirstName""=COALESCE(@FirstName,""FirstName""),
                ""LastName""=COALESCE(@LastName,""LastName""),
                ""ContactTitle""=COALESCE(@ContactTitle,""ContactTitle""),
                ""ContactPhone""=COALESCE(@ContactPhone,""ContactPhone""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus""),
                ""fkStoreLocationsID""=COALESCE(@fkStoreLocationsID,""fkStoreLocationsID""),
                ""ContactEmail""=COALESCE(@ContactEmail,""ContactEmail"")
                WHERE ""CompanyContactsID""=@CompanyContactsID;
                "
            },
            {"CompanyContactsDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblCompanyContacts""
                WHERE ""CompanyContactsID""=@CompanyContactsID;
                "
            },
            {"CompanyContactsGetAllAsync",
                @"
                SELECT*
                FROM public.""tblCompanyContacts"";
                "
            },
            {"CompanyContactsGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblCompanyContacts""
                WHERE ""CompanyContactsID""=@CompanyContactsID;
                "
            },
            //CompanyOrders Queries
            {"CompanyOrdersInsertAsync",
                @"
                INSERT INTO public.""tblCompanyOrders""
                (
                    ""fkStoreLocationsID"",
                    ""fkProductOrderingDetailsID"",
                    ""OrderAuthorizedBy"",
                    ""CompanyPurchaseDescription"",
                    ""CompanyOrderCosts"",
                    ""DateTimeOrdered"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @fkStoreLocationsID,
                    @fkProductOrderingDetailsID,
                    @OrderAuthorizedBy,
                    @CompanyPurchaseDescription,
                    @CompanyOrderCosts,
                    CURRENT_TIMESTAMP,
                    @ActiveStatus
                )RETURNING ""CompanyOrdersID"";
                "
            },
            {"CompanyOrdersUpdateByIdAsync",
                @"
                UPDATE public.""tblCompanyOrders""
                SET
                ""fkStoreLocationsID""=COALESCE(@fkStoreLocationsID,""fkStoreLocationsID""),
                ""fkProductOrderingDetailsID""=COALESCE(@fkProductOrderingDetailsID,""fkProductOrderingDetailsID""),
                ""OrderAuthorizedBy""=COALESCE(@OrderAuthorizedBy,""OrderAuthorizedBy""),
                ""CompanyPurchaseDescription""=COALESCE(@CompanyPurchaseDescription,""CompanyPurchaseDescription""),
                ""CompanyOrderCosts""=COALESCE(@CompanyOrderCosts,""CompanyOrderCosts""),
                ""DateTimeOrdered""=COALESCE(CURRENT_TIMESTAMP,""DateTimeOrdered""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE ""CompanyOrdersID""=@CompanyOrdersID;
                "
            },
            {"CompanyOrdersDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblCompanyOrders""
                WHERE ""CompanyOrdersID""=@CompanyOrdersID;
                "
            },
            {"CompanyOrdersGetAllAsync",
                @"
                SELECT*
                FROM public.""tblCompanyOrders"";
                "
            },
            {"CompanyOrdersGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblCompanyOrders""
                WHERE ""CompanyOrdersID""=@CompanyOrdersID;
                "
            },
            //CPIIndex Queries
            {"CPIIndexInsertAsync",
                @"
                INSERT INTO public.""tblCPIIndex""
                (
                    ""ProductCPIDateEntry"",
                    ""CPIIndexValue""
                    ""ActiveStatus""
                )
                VALUES
                (
                    @ProductCPIDateEntry,
                    @CPIIndexValue,
                    @ActiveStatus
                )RETURNING ""CPIIndexID"";
                "
            },
            {"CPIIndexUpdateByIdAsync",
                @"
                UPDATE public.""tblCPIIndex""
                SET
                ""ProductCPIDateEntry""=COALESCE(@ProductCPIDateEntry,""ProductCPIDateEntry""),
                ""CPIIndexValue""=COALESCE(@CPIIndexValue,""CPIIndexValue""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE ""CPIIndexID""= @CPIIndexID;
                "
            },
            {"CPIIndexDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblCPIIndex""
                WHERE ""CPIIndexID""=@CPIIndexID;
                "
            },
            {"CPIIndexGetAllAsync",
                @"
                SELECT*
                FROM public.""tblCPIIndex"";
                "
            },
            {"CPIIndexGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblCPIIndex""
                WHERE ""CPIIndexID""=@CPIIndexID;
                "
            },
            //DistrictSalesZones Queries
            {"DistrictSalesZonesInsertAsync",
                @"
                INSERT INTO public.""tblDistrictSalesZones""
                (
                    ""DistrictManagerID"",
                    ""DistrictSalesZoneName"",
                    ""DistrictSalesZoneNumber"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @DistrictManagerID,
                    @DistrictSalesZoneName,
                    @DistrictSalesZoneNumber,
                    @ActiveStatus
                )
                RETURNING ""DistrictSalesZoneID"";
                "
            },
            {"DistrictSalesZonesUpdateByIdAsync",
                @"
                UPDATE public.""tblDistrictSalesZones""
                SET
                ""DistrictManagerID""=COALESCE(@DistrictManagerID,""DistrictManagerID""),
                ""DistrictSalesZoneName""=COALESCE(@DistrictSalesZoneName,""DistrictSalesZoneName""),
                ""DistrictSalesZoneNumber""=COALESCE(@DistrictSalesZoneNumber,""DistrictSalesZoneNumber""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE ""DistrictSalesZoneID""= @DistrictSalesZoneID;
                "
            },
            {"DistrictSalesZonesDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblDistrictSalesZones""
                WHERE ""DistrictSalesZoneID""=@DistrictSalesZoneID;
                "
            },
            {"DistrictSalesZonesGetAllAsync",
                @"
                SELECT*
                FROM public.""tblDistrictSalesZones"";
                "
            },
            {"DistrictSalesZonesGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblDistrictSalesZones""
                WHERE ""DistrictSalesZoneID""=@DistrictSalesZoneID;
                "
            },
            //ICECATProductCatalog Queries
            {"ICECATProductCatalogInsertAsync",
                @"
                INSERT INTO public.""tblICECATProductCatalog""
                (
                    ""ManufacturerProductID"",
                    ""EAN_UPC"",
                    ""HtmlPath"",
                    ""Limited"",
                    ""DistributorInfoUpdated"",
                    ""HighPic"",
                    ""HighPicSize"",
                    ""HighPicWidth"",
                    ""HighPicHeight"",
                    ""ProductID"",
                    ""Updated"",
                    ""Quality"",
                    ""ProdID"",
                    ""fkSupplierID"",
                    ""Catid"",
                    ""On_Market"",
                    ""ModelName"",
                    ""ProductView"",
                    ""InitialUnitPrice"",
                    ""DateAdded"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @ManufacturerProductID,
                    @EAN_UPC,
                    @HtmlPath,
                    @Limited,
                    @DistributorInfoUpdated,
                    @HighPic,
                    @HighPicSize,
                    @HighPicWidth,
                    @HighPicHeight,
                    @ProductID,
                    @Updated,
                    @Quality,
                    @ProdID,
                    @fkSupplierID,
                    @Catid,
                    @On_Market,
                    @ModelName,
                    @ProductView,
                    @InitialUnitPrice,
                    @DateAdded,
                    @ActiveStatus
                )RETURNING ""ICECATEProductCatalogID"";
                "
            },
            {"ICECATProductCatalogUpdateByIdAsync",
                @"
                UPDATE public.""tblICECATProductCatalog""
                SET
                ""ManufacturerProductID""=COALESCE(@ManufacturerProductID,""ManufacturerProductID""),
                ""EAN_UPC""=COALESCE(@EAN_UPC,""EAN_UPC""),
                ""HtmlPath""=COALESCE(@HtmlPath,""HtmlPath""),
                ""Limited""=COALESCE(@Limited,""Limited""),
                ""DistributorInfoUpdated""=COALESCE(@DistributorInfoUpdated,""DistributorInfoUpdated""),
                ""HighPic""=COALESCE(@HighPic,""HighPic""),
                ""HighPicSize""=COALESCE(@HighPicSize,""HighPicSize""),
                ""HighPicWidth""=COALESCE(@HighPicWidth,""HighPicWidth""),
                ""HighPicHeight""=COALESCE(@HighPicHeight,""HighPicHeight""),
                ""ProductID""=COALESCE(@ProductID,""ProductID""),
                ""Updated""=COALESCE(@Updated,""Updated""),
                ""Quality""=COALESCE(@Quality,""Quality""),
                ""ProdID""=COALESCE(@ProdID,""ProdID""),
                ""fkSupplierID""=COALESCE(@fkSupplierID,""fkSupplierID""),
                ""Catid""=COALESCE(@Catid,""Catid""),
                ""On_Market""=COALESCE(@On_Market,""On_Market""),
                ""ModelName""=COALESCE(@ModelName,""ModelName""),
                ""ProductView""=COALESCE(@ProductView,""ProductView""),
                ""InitialUnitPrice""=COALESCE(@InitialUnitPrice,""InitialUnitPrice""),
                ""DateAdded""=COALESCE(@DateAdded,""DateAdded""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE""ICECATEProductCatalogID""=@ICECATEProductCatalogID;
                "
            },
            {"ICECATProductCatalogDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblICECATProductCatalog""
                WHERE ""ICECATEProductCatalogID""=@ICECATEProductCatalogID;
                "
            },
            {"ICECATProductCatalogGetAllAsync",
                @"
                SELECT*
                FROM public.""tblICECATProductCatalog"";
                "
            },
            {"ICECATProductCatalogGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblICECATProductCatalog""
                WHERE ""ICECATEProductCatalogID""=@ICECATEProductCatalogID;
                "
            },
            {"ICECATProductCatalogGetDistinctCatID",
                @"
                SELECT DISTINCT ""Catid""
                FROM ""tblICECATProductCatalog"";
                "
            },
            {"ICECATProductCatalogGetProductsbyCatID",
                @"
                SELECT*
                FROM public.""tblICECATProductCatalog""
                WHERE ""Catid""=@Catid;
                "
            },
            //Inventory Queries
            {"InventoryInsertAsync",
                @"
                INSERT INTO public.""tblInventory""
                (
                    ""fkProductsCatalogID"",
                    ""QuantityInStock"",
                    ""PurchaseOrSale"",
                    ""SalesTimeStamp"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @fkProductsCatalogID,
                    @QuantityInStock,
                    @PurchaseOrSale,
                    CURRENT_TIMESTAMP,
                    @ActiveStatus
                )RETURNING ""InventoryID"";
                "
            },
            {"InventoryUpdateByIdAsync",
                @"
                UPDATE public.""tblInventory""
                SET
                ""fkProductsCatalogID""=COALESCE(@fkProductsCatalogID,""fkProductsCatalogID""),
                ""QuantityInStock""=COALESCE(@QuantityInStock,""QuantityInStock""),
                ""PurchaseOrSale""=COALESCE(@PurchaseOrSale,""PurchaseOrSale""),
                ""SalesTimeStamp""=COALESCE(CURRENT_TIMESTAMP,""SalesTimeStamp""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE ""InventoryID""=@InventoryID;
                "
            },
            {"InventoryDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblInventory""
                WHERE ""InventoryID""=@InventoryID;
                "
            },
            {"InventoryGetAllAsync",
                @"
                SELECT*
                FROM public.""tblInventory"";
                "
            },
            {"InventoryGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblInventory""
                WHERE ""InventoryID""=@InventoryID;
                "
            },
            //ProductOrderDetails Queries
            {"ProductOrderDetailsInsertAsync",
                @"
                INSERT INTO public.""tblProductOrdersDetails""
                (
                    ""fkProductCatalogID"",
                    ""QuatityofProductOrdered"",
                    ""fkCompanyOrdersID"",
                    ""LineItemCompanyOrderCosts"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @fkProductCatalogID,
                    @QuatityofProductOrdered,
                    @fkCompanyOrdersID,
                    @LineItemCompanyOrderCosts,
                    @ActiveStatus
                )RETURNING ""ProductOrdersID"";
                "
            },
            {"ProductOrderDetailsUpdateByIdAsync",
                @"
                UPDATE public.""tblProductOrdersDetails""
                SET
                ""fkProductCatalogID""=COALESCE(@fkProductCatalogID,""fkProductCatalogID""),
                ""QuatityofProductOrdered""=COALESCE(@QuatityofProductOrdered,""QuatityofProductOrdered""),
                ""fkCompanyOrdersID""=COALESCE(@fkCompanyOrdersID,""fkCompanyOrdersID""),
                ""LineItemCompanyOrderCosts""=COALESCE(@LineItemCompanyOrderCosts,""LineItemCompanyOrderCosts""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE ""ProductOrdersID""=@ProductOrdersID;
                "
            },
            {"ProductOrderDetailsDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblProductOrdersDetails""
                WHERE ""ProductOrdersID""=@ProductOrdersID;
                "
            },
            {"ProductOrderDetailsGetAllAsync",
                @"
                SELECT*
                FROM public.""tblProductOrdersDetails"";
                "
            },
            {"ProductOrderDetailsGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblProductOrdersDetails""
                WHERE ""ProductOrdersID""=@ProductOrdersID;
                "
            },
            //ProductsCatalog Queries
            {"ProductsCatalogInsertAsync",
                @"
                INSERT INTO public.""tblProductsCatalog""
                (
                    ""productCompanyPurchaseDescription"",
                    ""SaleAuthorizedBy"",
                    ""UniversalProductID"",
                    ""fkCompaniesID"",
                    ""BaseRetailPrice"",
                    ""BaseWholeSalePrice"",
                    ""DateItemAddedUpdated"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @productCompanyPurchaseDescription,
                    @SaleAuthorizedBy,
                    @UniversalProductID,
                    @fkCompaniesID,
                    @BaseRetailPrice,
                    @BaseWholeSalePrice,
                    CURRENT_TIMESTAMP,
                    @ActiveStatus
                )RETURNING ""ProductCatalogID"";
                "
            },
            {"ProductsCatalogUpdateByIdAsync",
                @"
                UPDATE public.""tblProductsCatalog""
                SET
                ""productCompanyPurchaseDescription""=COALESCE(@productCompanyPurchaseDescription,""productCompanyPurchaseDescription""),
                ""UniversalProductID""=COALESCE(@UniversalProductID,""UniversalProductID""),
                ""fkCompaniesID""=COALESCE(@fkCompaniesID,""fkCompaniesID""),
                ""BaseRetailPrice""=COALESCE(@BaseRetailPrice,""BaseRetailPrice""),
                ""BaseWholeSalePrice""=COALESCE(@BaseWholeSalePrice,""BaseWholeSalePrice""),
                ""DateItemAddedUpdated""=COALESCE(CURRENT_TIMESTAMP,""DateItemAddedUpdated""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE ""ProductCatalogID""=@ProductCatalogID;
                "
            },
            {"ProductsCatalogDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblProductsCatalog""
                WHERE ""ProductsCatalogID""=@ProductsCatalogID;
                "
            },
            {"ProductsCatalogGetAllAsync",
                @"
                SELECT*
                FROM public.""tblProductsCatalog"";
                "
            },
            {"ProductsCatalogGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblProductsCatalog""
                WHERE ""ProductsCatalogID""=@ProductsCatalogID;
                "
            },
            //RegionalTerritories Queries
            {"RegionalTerritoriesInsertAsync",
                @"
                INSERT INTO public.""tblRegionalTerritories""
                (
                    ""fkDistrictSalesZoneID"",
                    ""RegionalSupervisorID"",
                    ""TerritoryColorCode"",
                    ""TerritoryGeometry"",
                    ""TerritoryNumber"",
                    ""TerritoryPerimeterLength"",
                    ""TerritoryArea"",
                    ""TerritoryAccount"",
                    ""territoryCompanyPurchaseDescription"",
                    ""DateTerritoryAddedUpdated"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @fkDistrictSalesZoneID,
                    @RegionalSupervisorID,
                    @TerritoryColorCode,
                    @TerritoryGeometry,
                    @TerritoryNumber,
                    @TerritoryPerimeterLength,
                    @TerritoryArea,
                    @TerritoryAccount,
                    @territoryCompanyPurchaseDescription,
                    CURRENT_TIMESTAMP,
                    @ActiveStatus
                )RETURNING ""RegionalTerritoriesID"";
                "
            },
            {"RegionalTerritoriesUpdateByIdAsync",
                @"
                UPDATE public.""tblRegionalTerritories""
                SET
                ""fkDistrictSalesZoneID""=COALESCE(@fkDistrictSalesZoneID,""fkDistrictSalesZoneID""),
                ""RegionalSupervisorID""=COALESCE(@RegionalSupervisorID,""RegionalSupervisorID""),
                ""TerritoryColorCode""=COALESCE(@TerritoryColorCode,""TerritoryColorCode""),
                ""TerritoryGeometry""=COALESCE(@TerritoryGeometry,""TerritoryGeometry""),
                ""TerritoryNumber""=COALESCE(@TerritoryNumber,""TerritoryNumber""),
                ""TerritoryPerimeterLength""=COALESCE(@TerritoryPerimeterLength,""TerritoryPerimeterLength""),
                ""TerritoryArea""=COALESCE(@TerritoryArea,""TerritoryArea""),
                ""TerritoryAccount""=COALESCE(@TerritoryAccount,""TerritoryAccount""),
                ""territoryCompanyPurchaseDescription""=COALESCE(@territoryCompanyPurchaseDescription,""territoryCompanyPurchaseDescription""),
                ""DateTerritoryAddedUpdated""=COALESCE(CURRENT_TIMESTAMP,""DateTerritoryAddedUpdated""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE ""RegionalTerritoriesID""=@RegionalTerritoriesID;
                "
            },
            {"RegionalTerritoriesDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblRegionalTerritories""
                WHERE ""RegionalTerritoriesID""=@RegionalTerritoriesID;
                "
            },
            {"RegionalTerritoriesGetAllAsync",
                @"
                SELECT*
                FROM public.""tblRegionalTerritories"";
                "
            },
            {"RegionalTerritoriesGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblRegionalTerritories""
                WHERE ""RegionalTerritoriesID""=@RegionalTerritoriesID;
                "
            },
            //Sales Queries
            {"SalesInsertAsync",
                @"
                INSERT INTO public.""tblSales""
                (
                    ""SalesInvoiceNumber"",
                    ""fkStoreLocationsID"",
                    ""transactionCompanyPurchaseDescription"",
                    ""SalesNotesToClient"",
                    ""SalesDate"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @SalesInvoiceNumber,
                    @fkStoreLocationsID,
                    @transactionCompanyPurchaseDescription,
                    @SalesNotesToClient,
                    CURRENT_TIMESTAMP,
                    @ActiveStatus
                )RETURNING ""SalesID"";
                "
            },
            {"SalesUpdateByIdAsync",
                @"
                UPDATE public.""tblSales""
                SET
                ""SalesInvoiceNumber""=COALESCE(@SalesInvoiceNumber,""SalesInvoiceNumber""),
                ""SaleAuthorizedBy""=COALESCE(@SaleAuthorizedBy,""SaleAuthorizedBy""),
                ""fkStoreLocationsID""=COALESCE(@fkStoreLocationsID,""fkStoreLocationsID""),
                ""transactionCompanyPurchaseDescription""=COALESCE(@transactionCompanyPurchaseDescription,""transactionCompanyPurchaseDescription""),
                ""SalesNotesToClient""=COALESCE(@SalesNotesToClient,""SalesNotesToClient""),
                ""SalesDate""=COALESCE(CURRENT_TIMESTAMP,""SalesDate""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus"")
                WHERE ""SalesID""=@SalesID;
                "
            },
            {"SalesDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblSales""
                WHERE ""SalesID""=@SalesID;
                "
            },
            {"SalesGetAllAsync",
                @"
                SELECT*
                FROM public.""tblSales"";
                "
            },
            {"SalesGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblSales""
                WHERE ""SalesID""=@SalesID;
                "
            },
            //SalesDetails Queries
            {"SalesDetailsInsertAsync",
                @"
                INSERT INTO public.""tblSalesDetails""
                (
                    ""fkSalesID"",
                    ""fkProductsCatalog"",
                    ""QuatitySold"",
                    ""SalesSpecialNotes"",
                    ""CompanyPurchaseDescription"",
                    ""SalesDiscountAmount"",
                    ""SalesLineItemCharge"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @fkSalesID,
                    @fkProductsCatalog,
                    @QuatitySold,
                    @SalesSpecialNotes,
                    @CompanyPurchaseDescription,
                    @SalesDiscountAmount,
                    @SalesLineItemCharge,
                    CURRENT_TIMESTAMP,
                    @ActiveStatus
                )RETURNING ""SalesDetailsID"";
                "
            },
            {"SalesDetailsUpdateByIdAsync",
                @"
                UPDATE public.""tblSalesDetails""
                SET
                ""fkSalesID""=COALESCE(@fkSalesID,""fkSalesID""),
                ""fkProductsCatalog""=COALESCE(@fkProductsCatalog,""fkProductsCatalog""),
                ""QuatitySold""=COALESCE(@QuatitySold,""QuatitySold""),
                ""SalesSpecialNotes""=COALESCE(@SalesSpecialNotes,""SalesSpecialNotes""),
                ""CompanyPurchaseDescription""=COALESCE(@CompanyPurchaseDescription,""CompanyPurchaseDescription""),
                ""SalesDiscountAmount""=COALESCE(@SalesDiscountAmount,""SalesDiscountAmount""),
                ""SalesLineItemCharge""=COALESCE(@SalesLineItemCharge,""SalesLineItemCharge""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus""
                WHERE ""SalesDetailsID""=@SalesDetailsID;
                "
            },
            {"SalesDetailsDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblSalesDetails""
                WHERE ""SalesDetailsID""=@SalesDetailsID;
                "
            },
            {"SalesDetailsGetAllAsync",
                @"
                SELECT*
                FROM public.""tblSalesDetails"";
                "
            },
            {"SalesDetailsGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblSalesDetails""
                WHERE ""SalesDetailsID""=@SalesDetailsID;
                "
            },
            //StoreLocations Queries
            {"StoreLocationsInsertAsync",
                @"
                INSERT INTO public.""tblStoreLocations""
                 (
                    ""fkRegionalTerritoriesID"",
                    ""fkCompaniesID"",
                    ""StoreName"",
                    ""StoreLocation"",
                    ""StoreStreet"",
                    ""StoreCity""
                    ""StoreState"",
                    ""StoreZipCode"",
                    ""StoreCountryCode"",
                    ""StoreEmail"",
                    ""StorePhone"",
                    ""StoreCategory"",
                    ""DateRegistered"",
                    ""ActiveStatus""
                 )
                 VALUES
                 (
                     @fkRegionalTerritoriesID,
                     @fkCompaniesID,
                     @StoreName,
                     @StoreLocation,
                     @StoreStreet,
                     @StoreCity,
                     @StoreState,
                     @StoreZipCode,
                     @StoreCountryCode,
                     @StoreEmail,
                     @StorePhone,
                     @StoreCategory,
                     CURRENT_TIMESTAMP,
                     @ActiveStatus
                 ) RETURNING ""StorelocationsID"";
                "
            },
            {"StoreLocationsUpdateByIdAsync",
                @"
                UPDATE public.""tblStoreLocations""
                SET
                ""fkRegionalTerritoriesID""=COALESCE(@fkRegionalTerritoriesID,""fkRegionalTerritoriesID""),
                ""fkCompaniesID""=COALESCE(@fkCompaniesID,""fkCompaniesID""),
                ""StoreName""=COALESCE(@StoreName,""StoreName""),
                ""StoreLocation""=COALESCE(@StoreLocation,""StoreLocation""),
                ""StoreStreet""=COALESCE(@StoreStreet,""StoreStreet""),
                ""StoreCity""=COALESCE(@StoreCity,""StoreCity""),
                ""StoreState""=COALESCE(@StoreState,""StoreState""),
                ""StoreZipCode""=COALESCE(@StoreZipCode,""StoreZipCode""),
                ""StoreCountryCode""=COALESCE(@StoreCountryCode,""StoreCountryCode""),
                ""StoreEmail""=COALESCE(@StoreEmail,""StoreEmail""),
                ""StorePhone""=COALESCE(@StorePhone,""StorePhone""),
                ""StoreCategory""=COALESCE(@StoreCategory,""StoreCategory""),
                ""DateRegistered""=COALESCE(@,""DateRegistered""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus""
                WHERE ""StorelocationsID""=@StorelocationsID;
                "
            },
            {"StoreLocationsDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblStoreLocations""
                WHERE ""StoreLocationsID""=@StoreLocationsID;
                "
            },
            {"StoreLocationsGetAllAsync",
                @"
                SELECT*
                FROM public.""tblStoreLocations"";
                "
            },
            {"StoreLocationsGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblStoreLocations""
                WHERE ""StoreLocationsID""=@StoreLocationsID;
                "
            },
            //ZoneDistributionCenters Queries
            {"ZoneDistributionCentersInsertAsync",
                @"
                INSERT INTO public.""tblZoneDistributionCenters""
                (
                    ""fkDistrictSalesZoneID""
                    ""ZoneDistributionCenterLocation"",
                    ""ZoneDistributionCenterStreet"",
                    ""ZoneDistributionCenterCity"",
                    ""ZoneDistributionCenterState"",
                    ""ZoneDistributionCenterZipCode"",
                    ""ZoneDistributionCenterCountryCode"",
                    ""ZoneDistributionCenterCode"",
                    ""ActiveStatus""
                )
                VALUES
                (
                    @fkDistrictSalesZoneID,
                    @ZoneDistributionCenterLocation,
                    @ZoneDistributionCenterStreet,
                    @ZoneDistributionCenterCity,
                    @ZoneDistributionCenterState,
                    @ZoneDistributionCenterZipCode,
                    @ZoneDistributionCenterCountryCode,
                    @ZoneDistributionCenterCode,
                    @ActiveStatus
                )RETURNING ""ZoneDistributionCenterID"";
                "
            },
            {"ZoneDistributionCentersUpdateByIdAsync",
                @"
                UPDATE public.""tblZoneDistributionCenters""
                SET
                ""fkDistrictSalesZoneID""=COALESCE(@fkDistrictSalesZoneID,""fkDistrictSalesZoneID""),
                ""ZoneDistributionCenterLocation""=COALESCE(@ZoneDistributionCenterLocation,""ZoneDistributionCenterLocation""),
                ""ZoneDistributionCenterStreet""=COALESCE(@ZoneDistributionCenterStreet,""ZoneDistributionCenterStreet""),
                ""ZoneDistributionCenterCity""=COALESCE(@ZoneDistributionCenterCity,""ZoneDistributionCenterCity""),
                ""ZoneDistributionCenterState""=COALESCE(@ZoneDistributionCenterState,""ZoneDistributionCenterState""),
                ""ZoneDistributionCenterZipCode""=COALESCE(@ZoneDistributionCenterZipCode,""ZoneDistributionCenterZipCode""),
                ""ZoneDistributionCenterCountryCode""=COALESCE(@ZoneDistributionCenterCountryCode,""ZoneDistributionCenterCountryCode""),
                ""ZoneDistributionCenterCode""=COALESCE(@ZoneDistributionCenterCode,""ZoneDistributionCenterCode""),
                ""ActiveStatus""=COALESCE(@ActiveStatus,""ActiveStatus""
                WHERE ""ZoneDistributionCenterID""= @ZoneDistributionCenterID;
                "
            },
            {"ZoneDistributionCentersDeleteTrueByIdAsync",
                @"
                DELETE FROM ""tblZoneDistributionCenters""
                WHERE ""ZoneDistributionCenterID""=@ZoneDistributionCenterID;
                "
            },
            {"ZoneDistributionCentersGetAllAsync",
                @"
                SELECT*
                FROM public.""tblZoneDistributionCenters"";
                "
            },
            {"ZoneDistributionCentersGetByIdAsync",
                @"
                SELECT*
                FROM public.""tblZoneDistributionCenters""
                WHERE ""ZoneDistributionCenterID""=@ZoneDistributionCenterID;
                "
            },
        };
    }
}
