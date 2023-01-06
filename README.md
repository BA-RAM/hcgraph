# Hot Chocolate GraphQL Sample Proj

:rocket: **Feel free to contribute**

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

## GraphQL Query Examples

### Simple Query
```
query {
  orders {
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
```

### Filtering
```
query {
  orders(where: { orderNumber: { contains: "Order_1" } }) {
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
```

## Resources
https://graphql.org/

https://chillicream.com/docs/hotchocolate/v12

https://chillicream.com/products/bananacakepop
