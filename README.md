# Hot Chocolate GraphQL Sample Proj

:rocket: **Feel free to contribute**

## Contents
* [Setup](https://github.com/BA-RAM/hcgraph/blob/main/README.md#setup)
* [Code Analyzation](https://github.com/BA-RAM/hcgraph/blob/main/README.md#code-analyzation)
* [GraphQL Query Examples](https://github.com/BA-RAM/hcgraph/blob/main/README.md#graphql-query-examples)
* [Resources](https://github.com/BA-RAM/hcgraph/blob/main/README.md#resources)

## Setup

1. Clone Repo (or download code directly from GH)
2. Build Solution
3. Open Terminal in Visual Studio
   - Navigate to the directory containing the .csproj
   - Ensure .NET EF tools are installed
     - From terminal, run `dotnet ef`
     - If you receive an error (unknown command) run `dotnet tool install --global dotnet-ef`
   - Run the following commands:
     - Setup Initial EF Core Migration: `dotnet ef migrations add initial`
     - Create (update) SQLite Database: `dotnet ef database update`
4. Run/Debug Solution

:warning: You may receive prompts regarding https certs. Allow it to create a cert and trust it.

A browser window will launch (https://localhost:[port]). Note, this window will not navigate anywhere. You must navigate to https://localhost:[port]/graphql/ to get to the Banana Cake Pop playground.

<img width="1349" alt="image" src="https://user-images.githubusercontent.com/27896263/211103225-354180c8-1d0c-4491-a7b7-9ddf5bcfa6e2.png">

## Code Analyzation
VS Code users enable the following VS Code settings for code analyzation:

<img width="459" alt="image" src="https://user-images.githubusercontent.com/27896263/213287083-0a2a5786-ca45-4e1c-8933-4b9dfe7e6ef7.png">

<img width="666" alt="image" src="https://user-images.githubusercontent.com/27896263/213287147-43ba2186-17fd-4e4f-8b2a-5b64acc46a85.png">

## GraphQL Query Examples

### Simple Query

```
query {
  orders {
    edges {
      node {
        rowId
        orderNumber
        orderItems {
          rowId
          displayName
          total
          quantity
          item {
            rowId
            itemNumber
            name
            price
          }
        }
      }
    }
    pageInfo {
      hasNextPage
      hasPreviousPage
    }
  }
}

```

### By Param/Variable

```
query ($orderId: Long!) {
  order(rowId: $orderId) {
    rowId
    orderNumber
    orderItems {
      rowId
      displayName
      total
      quantity
      item {
        rowId
        itemNumber
        name
        price
      }
    }
  }
}

variables:
{
  "orderId": 1
}
```

### Sorting

```
query {
  orders(order: [{ orderNumber: DESC }]) {
    edges {
      node {
        rowId
        orderNumber
        orderItems {
          rowId
          displayName
          total
          quantity
          item {
            rowId
            itemNumber
            name
            price
          }
        }
      }
    }
    pageInfo {
      hasNextPage
      hasPreviousPage
    }
  }
}

```

### Filtering

```
query {
  orders(where: { orderNumber: { contains: "Order_1" } }) {
    edges {
      node {
        rowId
        orderNumber
        orderItems {
          rowId
          displayName
          total
          quantity
          item {
            rowId
            itemNumber
            name
            price
          }
        }
      }
    }
    pageInfo {
      hasNextPage
      hasPreviousPage
    }
  }
```

### Paging

```
query {
  orders(first: 1) {
    edges {
      node {
        rowId
        orderNumber
        orderItems {
          rowId
          displayName
          total
          quantity
          item {
            rowId
            itemNumber
            name
            price
          }
        }
      }
    }
    pageInfo {
      hasNextPage
      hasPreviousPage
    }
  }
}
```

### Mutations

```
mutation addOrderItem($input: AddOrderItemInput!)
{
  addOrderItem(input: $input) {
    orderItem {
      rowId
      orderId
      quantity
      itemId
    }
  }
}

variables:
{
  "input": {
    "orderID": 1,
    "itemNumber": "Y_123",
    "quantity": 2
  }
}
```

## Resources

https://graphql.org/

https://chillicream.com/docs/hotchocolate/v12

https://chillicream.com/products/bananacakepop
