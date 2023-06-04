using OfficeOpenXml;
using UpStorage.Domain.Common.Interfaces;
using UpStorage.Domain.Common.Models.Email;
using UpStorage.Domain.Entities;

namespace UpStorage.Crawler.GetUser
{
    public class ExcelProcess
    {
        private readonly IEmailService _emailService;
        string filePath = $"C:\\Users\\{Environment.UserName}\\Desktop\\Products.xlsx";
        public void WriteAndSendList(List<Product> allProductList)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Products");

                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Picture";
                worksheet.Cells[1, 3].Value = "IsOnSale";
                worksheet.Cells[1, 4].Value = "Price";
                worksheet.Cells[1, 5].Value = "SalePrice";

                for(int i = 0; i < allProductList.Count; i++)
                {
                    worksheet.Cells[i +2,1].Value = allProductList[i].Name;
                    worksheet.Cells[i +2,2].Value = allProductList[i].Picture;
                    worksheet.Cells[i +2,3].Value = allProductList[i].IsOnSale;
                    worksheet.Cells[i +2,4].Value = allProductList[i].Price;
                    worksheet.Cells[i +2,5].Value = allProductList[i].SalePrice;

                }

                FileInfo file = new FileInfo(filePath);
                package.SaveAs(file);
            }

            _emailService.SendEmailConfirmation(new SendEmailConfirmationDto
            {
                Email= "noreply@entegraturk.com",
                Name="UpStorageBot"
            });
        }

    }
}
