using System.Text.RegularExpressions;
using Automation.Tests.Core.Config;
using Microsoft.Playwright;

namespace Automation.Tests.Ui.Pages;

public class ProductPage
{
    private readonly IPage _page;

    public ProductPage(IPage page)
    {
        _page = page;
    }

    private ILocator Image => _page.GetByTestId("feature-image");
    private ILocator ProductName => _page.Locator("h1[itemprop='name']"); //<h1 itemprop="name">Noir jacket</h1>
    private ILocator Price => _page.Locator("span.product-price"); //<span class="product-price">£60.00</span>
    private ILocator SizeSelector => _page.Locator("#product-select-option-0"); //<select class="single-option-selector" data-option="option1" id="product-select-option-0"><option value="S">S</option><option value="M">M</option><option value="L">L</option></select>

    //TODO: use better locator since it seems fragile to use "option-0" and "option-1"; 
    private ILocator ColorSelector => _page.Locator("#product-select-option-1"); //<select class="single-option-selector" data-option="option2" id="product-select-option-1"><option value="Blue">Blue</option><option value="Red">Red</option></select>
    private ILocator AddToCartButton =>
        _page.GetByRole(
            AriaRole.Button,
            new()
            {
                NameRegex = new Regex("add to cart", RegexOptions.IgnoreCase), //<input type="submit" value="Add to Cart" id="add" class="btn add-to-cart" style="opacity: 1;">
            }
        );

    // TODO: Make this method generic to use product names (even in url format with dashes)
    public async Task OpenSpecificProduct()
    {
        await _page.GotoAsync("https://sauce-demo.myshopify.com/products/noir-jacket");
    }

    //TODO: use Models.Product and TestData.ProductTestData when ready
    public async Task CheckProductName(string expectedName)
    {
        await Assertions.Expect(ProductName).ToHaveTextAsync(expectedName);
    }

    //TODO: combine this method and the one above into one generic like "CheckProductDetails"
    public async Task CheckProductPrice(string expectedPrice)
    {
        await Assertions.Expect(Price).ToHaveTextAsync(expectedPrice);
    }

    public async Task SelectProductSize(string size)
    {
        await SizeSelector.SelectOptionAsync(size);
    }

    public async Task SelectProductColor(string color)
    {
        await SizeSelector.SelectOptionAsync(color);
    }

    public async Task AddProductToCart()
    {
        await AddToCartButton.ClickAsync();
    }

    public async Task CheckIfProductIsInCart()
    {
        //TODO: use CartSummaryComponent when ready to check if the label indicate 1, not 0 items
    }
}
