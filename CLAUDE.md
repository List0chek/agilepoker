# Agile Poker Project Guidelines

## General Rules

- NEVER add `Co-Authored-By: Claude` or any Claude/AI attribution to commit messages.

## Project Structure

```
agilepoker/
  client/          — React + TypeScript frontend
  server/          — .NET 10 ASP.NET Core backend
    DataService/   — netstandard2.1 class library: models, repositories, IRepository<T>
    PlanPoker/     — net10.0 ASP.NET Core Web API: controllers, services, DTOs
    Tests/         — net10.0 NUnit 4 test project
  dotNet module/   — standalone .NET learning tasks
```

## Frontend (client/)

### Tech Stack

- React 17, TypeScript 4, Redux (classic `combineReducers`), React Router v5
- `connect()` for Redux binding; `async/await` for all API calls
- Per-component CSS files (imported directly in TSX)

### Files & Naming

- PascalCase for component files and directories: `Card/Card.tsx`, `RoomPage/RoomPage.tsx`
- `index.tsx` is the app entry point (in `src/`)

### Components

- `React.FunctionComponent<IProps>` for functional components
- Class components are allowed (existing code uses both patterns)
- Props interface: `I`-prefix, e.g., `interface IProps { ... }` declared above the component
- Default export for the component

### TypeScript

- `Array<T>` generic syntax — never `T[]`
- No `any`. No non-null assertion (`!`)
- Interfaces: `I` prefix, PascalCase (`IUser`, `IRootState`, `ICard`)
- Enums: PascalCase, no prefix
- Type aliases: PascalCase, no prefix
- Interface member delimiter: semicolon, required on last member in multiline
- Single quotes for strings
- Semicolons always
- Trailing commas: allowed in multi-line objects/arrays

### Formatting

- 2-space indentation
- Single quotes
- Semicolons always
- Trailing commas in multi-line arrays/objects
- Max line length: 150 characters
- Brace style: Stroustrup
- Code block should not be on the same line with condition in conditional statements; body must always be on a new line; prefer no curly braces for single-statement bodies
- Object curlies: space inside `{ foo }`
- No trailing spaces. No multiple empty lines
- Empty line at the end of every file
- Comments must have space after `//`

### Imports

- React import first, then third-party, then local
- CSS imports at the end of the import block
- No duplicate imports

### Redux

- Classic Redux with `combineReducers`, `ActionType` string constants, manual action creators
- Root state type: `IRootState` in `store/Types.ts`
- Sub-reducers in `store/<Domain>/` folders
- `connect(mapStateToProps)(Component)` for component binding

### API Layer

- All request functions in `src/api/Api.ts`; exported as named async functions
- `FetchWrapper.ts` wraps `fetch` with `post` / `get` helpers
- Auth token managed by `AuthService` (localStorage)
- Function naming: `<verb><Resource>Request` (e.g., `createUserRequest`, `getRoomInfoRequest`)

### Styling

- Per-component `.css` files imported in the TSX file
- `classnames` library for conditional class names
- No CSS-in-JS; no Tailwind; no MUI

### General Patterns

- `const` by default; `let` only when reassignment needed; no `var`
- `===` for equality (`== null` is allowed for null/undefined checks)
- Nullish coalescing `??` over `||` for defaults; optional chaining `?.` for safe access
- No `console.*` in production code
- Object shorthand: `{ foo }` not `{ foo: foo }`
- Arrow functions preferred for callbacks; no `.bind()` in JSX
- Self-closing tags required for empty JSX elements
- Boolean JSX props must be explicit: `disabled={true}` not just `disabled`

## Backend (server/)

### Tech Stack

- .NET 10, ASP.NET Core Web API (Startup class pattern)
- AutoMapper 13 (referenced but currently unused — custom DTO converters are used instead)
- NUnit 4 for tests

### Project Layout

```
server/
  DataService/          — net10.0 library
    Models/             — domain classes in namespace PlanPoker.Models
                          (Entity, IEntity in DataService.Models; models inherit from Entity)
    Repositories/       — IRepository<T> interface + InMemory implementations
  PlanPoker/            — net10.0 ASP.NET Core Web API
    Controllers/        — one controller per domain (RoomController, UserController…)
    Services/           — business logic services (RoomService, UserService…)
    DTO/                — data transfer objects + Converters/ subfolder
    Startup.cs          — DI registration and middleware pipeline
    Program.cs          — IHostBuilder entry point
  Tests/                — net10.0 NUnit 4 test project
```

### Namespace Convention

- Base infrastructure (`Entity`, `IEntity`, `IRepository<T>`, `InMemoryRepository<T>`) → `DataService.Models` / `DataService` / `DataService.Repositories`
- Domain models (`Card`, `Room`, `User`, `Vote`, `Discussion`, `Deck`) → `PlanPoker.Models` (files live in `DataService/Models/`)
- Everything in PlanPoker project → `PlanPoker.*`

### Formatting (C#)

- **2-space indentation**
- **Allman brace style**: opening brace on its own line for types, methods, and control flow
- `this.` prefix required for all instance member access
- Trailing commas: never
- Semicolons always
- Max line length: 150 characters
- Single blank line between methods inside a class
- XML documentation (`/// <summary>`) required on all public types and members

```csharp
/// <summary>
/// Short description.
/// </summary>
/// <param name="id">Description.</param>
/// <returns>Description.</returns>
public Room Get(Guid id)
{
  return this.InMemoryStorage.Find(item => item.Id.Equals(id));
}
```

### Patterns

- **Repository**: `IRepository<T>` with `Get`, `GetAll`, `Save`, `Delete`, `Create`; in-memory implementations inherit from `InMemoryRepository<T>`
- **Service**: plain classes with constructor-injected repositories; validation via `throw new ArgumentException` / `UnauthorizedAccessException`
- **DTO + Converter**: each DTO has a matching `<Name>DTOConverter` class with a `Convert()` method — no AutoMapper profiles
- **Dependency Injection**: all services and repositories registered in `Startup.ConfigureServices`; repositories as singletons, services as transient
- **Exception handling**: `CustomExceptionFilter : IExceptionFilter` converts exceptions to JSON responses (401 for `UnauthorizedAccessException`, 500 for others)
- **CORS**: `AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()` with `WithExposedHeaders("token")`

### Testing (NUnit 4)

- **Use `Assert.That()` exclusively** — classic methods (`Assert.AreEqual`, `Assert.IsNotNull`, `Assert.IsTrue`, etc.) are removed in NUnit 4
- Equivalents:
  - `Assert.AreEqual(expected, actual)` → `Assert.That(actual, Is.EqualTo(expected))`
  - `Assert.IsNotNull(obj)` → `Assert.That(obj, Is.Not.Null)`
  - `Assert.IsNull(obj)` → `Assert.That(obj, Is.Null)`
  - `Assert.IsTrue(expr)` → `Assert.That(expr, Is.True)`
  - `Assert.IsFalse(expr)` → `Assert.That(expr, Is.False)`
  - `Assert.Throws<T>(action)` → unchanged, still valid
  - `Assert.Multiple(() => { ... })` → unchanged, still valid
- Class-based tests, `[SetUp]` for fixtures, `[Test]` for test methods

## Code Reviews

- Every finding must include a precise file reference in the format `path/to/file.cs:line` or `path/to/file.cs:start-end`
- The change summary must also reference the exact file and line range for each change made
- References must be real — verify the line numbers against the actual file before writing them; never approximate or guess
