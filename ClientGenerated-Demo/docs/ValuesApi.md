# IO.Swagger.Api.ValuesApi

All URIs are relative to *https://localhost/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiValuesByIdByNameGet**](ValuesApi.md#apivaluesbyidbynameget) | **GET** /api/Values/{id}/{name} | Get a person matching given an id and name in input.
[**ApiValuesByIdGet**](ValuesApi.md#apivaluesbyidget) | **GET** /api/Values/{id} | Get a value
[**ApiValuesByIdPut**](ValuesApi.md#apivaluesbyidput) | **PUT** /api/Values/{id} | 
[**ApiValuesGet**](ValuesApi.md#apivaluesget) | **GET** /api/Values | 
[**ApiValuesPost**](ValuesApi.md#apivaluespost) | **POST** /api/Values | 


<a name="apivaluesbyidbynameget"></a>
# **ApiValuesByIdByNameGet**
> Person ApiValuesByIdByNameGet (int? id, string name)

Get a person matching given an id and name in input.

Sample request:                    GET api/values/1/helen

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesByIdByNameGetExample
    {
        public void main()
        {
            
            var apiInstance = new ValuesApi();
            var id = 56;  // int? | 
            var name = name_example;  // string | 

            try
            {
                // Get a person matching given an id and name in input.
                Person result = apiInstance.ApiValuesByIdByNameGet(id, name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesByIdByNameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **name** | **string**|  | 

### Return type

[**Person**](Person.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apivaluesbyidget"></a>
# **ApiValuesByIdGet**
> string ApiValuesByIdGet (int? id)

Get a value

Sample request:                    GET api/values/5

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesByIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new ValuesApi();
            var id = 56;  // int? | 

            try
            {
                // Get a value
                string result = apiInstance.ApiValuesByIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesByIdGet: " + e.Message );
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

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apivaluesbyidput"></a>
# **ApiValuesByIdPut**
> void ApiValuesByIdPut (int? id, string value = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesByIdPutExample
    {
        public void main()
        {
            
            var apiInstance = new ValuesApi();
            var id = 56;  // int? | 
            var value = value_example;  // string |  (optional) 

            try
            {
                apiInstance.ApiValuesByIdPut(id, value);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesByIdPut: " + e.Message );
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

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apivaluesget"></a>
# **ApiValuesGet**
> List<string> ApiValuesGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesGetExample
    {
        public void main()
        {
            
            var apiInstance = new ValuesApi();

            try
            {
                List&lt;string&gt; result = apiInstance.ApiValuesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**List<string>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apivaluespost"></a>
# **ApiValuesPost**
> void ApiValuesPost (string value = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiValuesPostExample
    {
        public void main()
        {
            
            var apiInstance = new ValuesApi();
            var value = value_example;  // string |  (optional) 

            try
            {
                apiInstance.ApiValuesPost(value);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ValuesApi.ApiValuesPost: " + e.Message );
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

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

