
using ObserverDP;

OrderItemViewModel viewModel = new("Shoes");

OrderItemView view = new(viewModel);

view.ClickIncreaseQuantityButton();

viewModel.Quantity = 5;

view.Dispose();

Console.ReadKey();