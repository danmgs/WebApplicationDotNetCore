# IO.Swagger.Api.ProductApi

All URIs are relative to *https://localhost/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiProductByIdDelete**](ProductApi.md#apiproductbyiddelete) | **DELETE** /api/Product/{id} | 
[**ApiProductByIdGet**](ProductApi.md#apiproductbyidget) | **GET** /api/Product/{id} | Get the product by the given id
[**ApiProductByIdPut**](ProductApi.md#apiproductbyidput) | **PUT** /api/Product/{id} | 
[**ApiProductGet**](ProductApi.md#apiproductget) | **GET** /api/Product | Get all the products
[**ApiProductPost**](ProductApi.md#apiproductpost) | **POST** /api/Product | 
[**ApiProductSearchByValueGet**](ProductApi.md#apiproductsearchbyvalueget) | **GET** /api/Product/search/{value} | Get a list of products matching the search term


<a name="apiproductbyiddelete"></a>
# **ApiProductByIdDelete**
> void ApiProductByIdDelete (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiProductByIdDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new ProductApi();
            var id = 56;  // int? | 

            try
            {
                apiInstance.ApiProductByIdDelete(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductByIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiproductbyidget"></a>
# **ApiProductByIdGet**
> void ApiProductByIdGet (int? id)

Get the product by the given id

Sample request:                    GET api/product/1

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiProductByIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new ProductApi();
            var id = 56;  // int? | 

            try
            {
                // Get the product by the given id
                apiInstance.ApiProductByIdGet(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiproductbyidput"></a>
# **ApiProductByIdPut**
> void ApiProductByIdPut (int? id, string value = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiProductByIdPutExample
    {
        public void main()
        {
            
            var apiInstance = new ProductApi();
            var id = 56;  // int? | 
            var value = value_example;  // string |  (optional) 

            try
            {
                apiInstance.ApiProductByIdPut(id, value);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductByIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **value** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiproductget"></a>
# **ApiProductGet**
> List<Product> ApiProductGet ()

Get all the products

Sample request:                    GET api/product/search

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiProductGetExample
    {
        public void main()
        {
            
            var apiInstance = new ProductApi();

            try
            {
                // Get all the products
                List&lt;Product&gt; result = apiInstance.ApiProductGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<Product>**](Product.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiproductpost"></a>
# **ApiProductPost**
> void ApiProductPost (string value = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiProductPostExample
    {
        public void main()
        {
            
            var apiInstance = new ProductApi();
            var value = value_example;  // string |  (optional) 

            try
            {
                apiInstance.ApiProductPost(value);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **value** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiproductsearchbyvalueget"></a>
# **ApiProductSearchByValueGet**
> List<Product> ApiProductSearchByValueGet (string value)

Get a list of products matching the search term

Sample request:                    GET api/product/search/wine

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiProductSearchByValueGetExample
    {
        public void main()
        {
            
            var apiInstance = new ProductApi();
            var value = value_example;  // string | 

            try
            {
                // Get a list of products matching the search term
                List&lt;Product&gt; result = apiInstance.ApiProductSearchByValueGet(value);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductApi.ApiProductSearchByValueGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **value** | **string**|  | 

### Return type

[**List<Product>**](Product.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

