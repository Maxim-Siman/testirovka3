using System;
using System.Net.Http;
using System.Threading.Tasks;

class HTTPS
{
    static async Task Main(string[] args)
    {
        string baseUrl = "https://petstore.swagger.io";

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);

        // Запросы для сущности "user"
        string getUserUrl = "/user/{username}";
        string createUserUrl = "/user";
        string updateUserUrl = "/user/{username}";
        string deleteUserUrl = "/user/{username}";

        // Запросы для сущности "store"
        string getStoreInventoryUrl = "/store/inventory";
        string placeOrderUrl = "/store/order";
        string getOrderUrl = "/store/order/{orderId}";
        string deleteOrderUrl = "/store/order/{orderId}";

        // Пример использования запросов
        string username = "exampleUser";
        string orderId = "1";

        // Получение информации о пользователе
        HttpResponseMessage getUserResponse = await client.GetAsync(getUserUrl.Replace("{username}", username));
        string getUserResult = await getUserResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Информация о пользователе: {getUserResult}");

        // Создание нового пользователя
        string newUserJson = "{\"username\":\"newUser\",\"email\":\"newuser@example.com\",\"password\":\"password123\"}";
        HttpResponseMessage createUserResponse = await client.PostAsync(createUserUrl, new StringContent(newUserJson));
        string createUserResult = await createUserResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат создания нового пользователя: {createUserResult}");

        // Обновление информации о пользователе
        string updatedUserJson = "{\"email\":\"updateduser@example.com\",\"password\":\"newpassword123\"}";
        HttpResponseMessage updateUserResponse = await client.PutAsync(updateUserUrl.Replace("{username}", username), new StringContent(updatedUserJson));
        string updateUserResult = await updateUserResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат обновления информации о пользователе: {updateUserResult}");

        // Удаление пользователя
        HttpResponseMessage deleteUserResponse = await client.DeleteAsync(deleteUserUrl.Replace("{username}", username));
        string deleteUserResult = await deleteUserResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат удаления пользователя: {deleteUserResult}");

        // Получение информации о товарах в магазине
        HttpResponseMessage getStoreInventoryResponse = await client.GetAsync(getStoreInventoryUrl);
        string getStoreInventoryResult = await getStoreInventoryResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Информация о товарах в магазине: {getStoreInventoryResult}");

        // Создание нового заказа
        string newOrderJson = "{\"id\":\"" + orderId + "\",\"petId\":1,\"quantity\":1,\"shipDate\":\"2022-01-01T00:00:00.000Z\",\"status\":\"placed\",\"complete\":false}";
        HttpResponseMessage placeOrderResponse = await client.PostAsync(placeOrderUrl, new StringContent(newOrderJson));
        string placeOrderResult = await placeOrderResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат создания нового заказа: {placeOrderResult}");

        // Получение информации о заказе
        HttpResponseMessage getOrderResponse = await client.GetAsync(getOrderUrl.Replace("{orderId}", orderId));
        string getOrderResult = await getOrderResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Информация о заказе: {getOrderResult}");

        // Удаление заказа
        HttpResponseMessage deleteOrderResponse = await client.DeleteAsync(deleteOrderUrl.Replace("{orderId}", orderId));
        string deleteOrderResult = await deleteOrderResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Результат удаления заказа: {deleteOrderResult}");
    }
}
