# Hot Chocolate GraphQL Sample Proj

## Setup

1) Clone Repo (or download code directly from GH)
2) Build Solution
3) Setup Initial EF Core Migration: `dotnet ef migrations add initial`
4) Create (update) SQLite Database: `dotnet ef database update`
5) Run/Debug Solution

A browser window will launch (https://localhost:5000). Note, this window will not navigate anywhere. You must navigate to https://localhost:5000/graphql/ to get to the Banana Cake Pop playground.

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
