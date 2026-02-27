# Agile Poker (Poker Planning)

A collaborative estimation tool for agile teams. Team members join a shared room, vote on user story effort using poker cards, and the moderator reveals results and calculates averages — all in real time via polling.

## Features

- Create a room with an initial discussion topic in one step
- Invite teammates via a shareable link
- Vote using a Fibonacci card deck (1, 2, 3, 5, 8, 13, coffee, ∞)
- Moderator (host) can open, close, and delete discussions
- Closed discussions show average estimate and per-user vote breakdown
- Host transfer to another room member

## Architecture

```
agilepoker/
├── client/          React 17 + TypeScript 4 single-page application
└── server/
    ├── DataService/ netstandard2.1 class library — domain models and in-memory repositories
    ├── PlanPoker/   net10.0 ASP.NET Core Web API — controllers, services, DTOs
    └── Tests/       net10.0 NUnit 4 test project
```

### Frontend (`client/`)

| Layer | Technology |
|---|---|
| UI | React 17, TypeScript 4 |
| State | Redux (classic `combineReducers`) + redux-thunk |
| Routing | React Router v5 |
| HTTP | Fetch API via `FetchWrapper` |
| Styling | Per-component CSS files, `classnames` |

**Key pages:**

- `CreateRoomPage` — landing page; creates user, room, and first discussion in one request
- `RoomPage` — main workspace; shows current discussion, voting board, completed stories; polls the backend every 3 seconds
- `InvitePage` — join an existing room by entering a username

**State slices:** `room`, `user`, `loadingIndicator`, `error`

**API base URL:** `http://localhost:5000/api` (configured in `client/src/api/Api.ts`)

### Backend (`server/`)

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 10 Web API |
| Persistence | In-memory repositories (no database) |
| DI | Built-in ASP.NET Core DI |
| Exception handling | `CustomExceptionFilter` (401 / 500 JSON responses) |
| Tests | NUnit 4 |

**Domain models:** `User`, `Room`, `Discussion`, `Vote`, `Card`, `Deck`

**Controllers and their routes:**

| Controller | Route prefix | Key actions |
|---|---|---|
| `UserController` | `/api/user` | `Create`, `Get`, `ChangeName`, `Delete` |
| `RoomController` | `/api/room` | `Create`, `AddMember`, `GetRoomInfo`, `ChangeHost`, `CreateUserAndRoomWithDiscussion` |
| `DiscussionController` | `/api/discussion` | `Create`, `SetVote`, `Close`, `Delete`, `GetResults` |
| `DeckController` | `/api/deck` | deck management |

**Auth:** each user receives a Base64 token on creation; the token is stored in `localStorage` and sent in request headers.

## Prerequisites

| Tool | Version |
|---|---|
| Node.js | 16 or later |
| npm | 8 or later |
| .NET SDK | 10.0 |

## Setup & Running

### 1. Backend

```bash
cd server
dotnet restore
dotnet run --project PlanPoker
```

The API listens on `http://localhost:5000`.

### 2. Frontend

```bash
cd client
npm install
npm start
```

The dev server starts on `http://localhost:3000` and proxies API calls to `http://localhost:5000`.

### 3. Tests

```bash
cd server
dotnet test
```

## Development Scripts (client)

| Command | Description |
|---|---|
| `npm start` | Start development server |
| `npm run build` | Production build to `client/build/` |
| `npm test` | Run Jest tests |
| `npm run lint` | Run ESLint + Stylelint |
| `npm run eslint:fix` | Auto-fix ESLint issues |

## How It Works

1. A user opens the app, enters a name, room name, and first discussion topic, and creates the room.
2. The creator becomes the **owner** and initial **host** (moderator).
3. Other users join via the invite link (`/invite/{roomId}`) and enter their name.
4. The host starts a discussion; all members see the voting board and select a card.
5. The host closes the discussion — votes are revealed and an average is calculated.
6. Completed discussions are listed with full vote breakdowns; the host can delete them.
7. The host can create additional discussions or transfer host rights to another member.
