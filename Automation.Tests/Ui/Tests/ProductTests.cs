using Automation.Tests.Core.Fixtures;
using Automation.Tests.Ui.Pages;

namespace Automation.Tests.Ui.Tests;

public class ProductTests : UiTestBase
{
    private ProductPage _productPage = null!;

    [SetUp]
    public void Setup()
    {
        var _productPage = new ProductPage(Page);
    }

    [Test]
    public async Task CheckProductAndAddToCart()
    {
        await _productPage.OpenSpecificProduct();
        await _productPage.CheckProductName("Noir jacket");
        await _productPage.CheckProductPrice("£60.00");
        await _productPage.AddProductToCart();
        // await _productPage.CheckIfProductIsInCart(); //TODO: uncomment when ready
    }

    //TODO: add more tests
}
