Below is the updated `bestsellerbooksapi.md` documentation with added summaries for each endpoint and their properties:

---

# Bestseller Books API Documentation

Welcome to the Bestseller Books API documentation. This API provides access to information about the top-selling books, including details about the authors, genres, and more.

## Base URL

```
https://api.bestsellerbooks.com/v1
```

## Authentication

All requests to the Bestseller Books API require an API key. You can obtain your API key by registering on our website.

To authenticate, include your API key in the `Authorization` header:

```
Authorization: Bearer YOUR_API_KEY
```

## Endpoints

### 1. Get All Bestsellers

**Summary:** Retrieve a paginated list of all bestseller books.

**Endpoint:** `/bestsellers`

**Method:** `GET`

**Description:** Retrieve a list of all bestseller books.

**Parameters:**

| Name    | Type   | Required | Summary                         | Description                                                 |
| ------- | ------ | -------- | ------------------------------- | ----------------------------------------------------------- |
| `page`  | int    | No       | The page number to retrieve.    | The page number for paginated results. Default is 1.        |
| `limit` | int    | No       | The number of results per page. | The number of results per page. Default is 10.              |
| `sort`  | string | No       | Field by which to sort results. | Sort results by a specific field (e.g., `title`, `author`). |

**Response:**

```json
{
  "page": 1,
  "limit": 10,
  "total": 100,
  "bestsellers": [
    {
      "id": "1",
      "title": "Book Title",
      "author": "Author Name",
      "genre": "Genre",
      "published_date": "2023-01-01",
      "isbn": "1234567890",
      "description": "A brief description of the book.",
      "cover_image_url": "https://example.com/image.jpg"
    },
    ...
  ]
}
```

### 2. Get Bestseller by ID

**Summary:** Retrieve detailed information about a specific bestseller book.

**Endpoint:** `/bestsellers/{id}`

**Method:** `GET`

**Description:** Retrieve detailed information about a specific bestseller book.

**Path Parameters:**

| Name | Type   | Required | Summary                            | Description               |
| ---- | ------ | -------- | ---------------------------------- | ------------------------- |
| `id` | string | Yes      | The unique identifier of the book. | The ID of the bestseller. |

**Response:**

```json
{
  "id": "1",
  "title": "Book Title",
  "author": "Author Name",
  "genre": "Genre",
  "published_date": "2023-01-01",
  "isbn": "1234567890",
  "description": "A brief description of the book.",
  "cover_image_url": "https://example.com/image.jpg",
  "publisher": "Publisher Name",
  "language": "English",
  "pages": 350
}
```

### 3. Add a New Bestseller

**Summary:** Add a new bestseller book to the list.

**Endpoint:** `/bestsellers`

**Method:** `POST`

**Description:** Add a new bestseller book to the list.

**Request Body:**

| Name              | Type   | Required | Summary                           | Description                          |
| ----------------- | ------ | -------- | --------------------------------- | ------------------------------------ |
| `title`           | string | Yes      | The title of the book.            | The title of the book.               |
| `author`          | string | Yes      | The author of the book.           | The author of the book.              |
| `genre`           | string | Yes      | The genre of the book.            | The genre of the book.               |
| `published_date`  | string | Yes      | The publication date of the book. | The publication date of the book.    |
| `isbn`            | string | Yes      | The ISBN of the book.             | The ISBN of the book.                |
| `description`     | string | No       | A brief description of the book.  | A brief description of the book.     |
| `cover_image_url` | string | No       | URL to the cover image.           | URL to the cover image of the book.  |
| `publisher`       | string | No       | The publisher of the book.        | The publisher of the book.           |
| `language`        | string | No       | The language of the book.         | The language the book is written in. |
| `pages`           | int    | No       | The number of pages in the book.  | The number of pages in the book.     |

**Request Example:**

```json
{
  "title": "New Book Title",
  "author": "New Author",
  "genre": "Fiction",
  "published_date": "2024-06-01",
  "isbn": "0987654321",
  "description": "A brief description of the new book.",
  "cover_image_url": "https://example.com/new_image.jpg",
  "publisher": "New Publisher",
  "language": "English",
  "pages": 300
}
```

**Response:**

```json
{
  "id": "101",
  "title": "New Book Title",
  "author": "New Author",
  "genre": "Fiction",
  "published_date": "2024-06-01",
  "isbn": "0987654321",
  "description": "A brief description of the new book.",
  "cover_image_url": "https://example.com/new_image.jpg",
  "publisher": "New Publisher",
  "language": "English",
  "pages": 300
}
```

### 4. Update a Bestseller

**Summary:** Update details of an existing bestseller book.

**Endpoint:** `/bestsellers/{id}`

**Method:** `PUT`

**Description:** Update details of an existing bestseller book.

**Path Parameters:**

| Name | Type   | Required | Summary                            | Description               |
| ---- | ------ | -------- | ---------------------------------- | ------------------------- |
| `id` | string | Yes      | The unique identifier of the book. | The ID of the bestseller. |

**Request Body:**

| Name              | Type   | Required | Summary                           | Description                          |
| ----------------- | ------ | -------- | --------------------------------- | ------------------------------------ |
| `title`           | string | No       | The title of the book.            | The title of the book.               |
| `author`          | string | No       | The author of the book.           | The author of the book.              |
| `genre`           | string | No       | The genre of the book.            | The genre of the book.               |
| `published_date`  | string | No       | The publication date of the book. | The publication date of the book.    |
| `isbn`            | string | No       | The ISBN of the book.             | The ISBN of the book.                |
| `description`     | string | No       | A brief description of the book.  | A brief description of the book.     |
| `cover_image_url` | string | No       | URL to the cover image.           | URL to the cover image of the book.  |
| `publisher`       | string | No       | The publisher of the book.        | The publisher of the book.           |
| `language`        | string | No       | The language of the book.         | The language the book is written in. |
| `pages`           | int    | No       | The number of pages in the book.  | The number of pages in the book.     |

**Request Example:**

```json
{
  "title": "Updated Book Title",
  "author": "Updated Author",
  "genre": "Non-Fiction",
  "published_date": "2024-07-01",
  "isbn": "1234509876",
  "description": "An updated description of the book.",
  "cover_image_url": "https://example.com/updated_image.jpg",
  "publisher": "Updated Publisher",
  "language": "English",
  "pages": 350
}
```

**Response:**

```json
{
  "id": "101",
  "title": "Updated Book Title",
  "author": "Updated Author",
  "genre": "Non-Fiction",
  "published_date": "2024-07-01",
  "isbn": "1234509876",
  "description": "An updated description of the book.",
  "cover_image_url": "https://example.com/updated_image.jpg",
  "publisher": "Updated Publisher",
  "language": "English",
  "pages": 350
}
```

### 5. Delete a Bestseller

**Summary:** Remove a bestseller book from the list.

**Endpoint:** `/bestsellers/{id}`

**Method:** `DELETE`

**Description:** Remove a bestseller book from the list.

**Path Parameters:**

| Name | Type   | Required | Summary                            | Description               |
| ---- | ------ | -------- | ---------------------------------- | ------------------------- |
| `id` | string | Yes      | The unique identifier of the book. | The ID of the bestseller. |

**Response:**

```json
{
  "message": "Bestseller book with ID 101 has been deleted."
}
```

## Error Handling

The API uses standard HTTP status codes to indicate the success or

failure of an API request. Errors are returned in the following format:

```json
{
  "error": {
    "code": 400,
    "message": "Bad Request",
    "details": "The request was invalid or cannot be otherwise served."
  }
}
```

## Rate Limiting

The API employs rate limiting to ensure fair usage. The current rate limit is 1000 requests per hour per user. If you exceed this limit, you will receive a `429 Too Many Requests` response.

## Contact

For support or inquiries, please contact us at support@mikias.bestsellerbooks.com.

---

This documentation provides a comprehensive overview of the Bestseller Books API, covering the essential endpoints and their functionalities, including the necessary details for making requests and understanding responses.
