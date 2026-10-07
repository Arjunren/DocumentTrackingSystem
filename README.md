# Document Tracking System

## Overview
ASP.NET Core API for registering, locating, reviewing, approving, rejecting, and archiving organizational documents.

## Features
- JWT authentication with Admin, Reviewer, and User roles
- Generated tracking numbers, search, status filters, pagination
- Owner-only standard-user visibility
- Draft → Submitted → InReview → Approved/Rejected → Archived workflow
- Immutable event history and reviewer dashboard

## Technology Stack
.NET 10, ASP.NET Core, EF Core 10, SQLite, JWT, xUnit, Docker.

## Requirements / Installation / Running
Install .NET SDK 10. Run `dotnet restore Documents.slnx` then `dotnet run --project src/Documents.Api`. The database is created automatically; `migrations/001_initial.sql` documents its schema. Docker: `docker build -t documents-api .` and `docker run -p 8080:8080 documents-api`.

## Environment Variables
Set values from `.env.example`, replacing `Jwt__Secret` and optionally changing the connection string and URL.

## Running Tests
Run `dotnet test Documents.slnx` and `dotnet list Documents.slnx package --vulnerable --include-transitive`.

## Default Development Accounts
`admin`, `reviewer`, and `user`, password `ChangeMe123!` (development only).

## API Endpoints
`POST /api/auth/login`; `GET/POST /api/documents`; `PATCH /api/documents/{id}/transition`; `GET /api/dashboard`.

## Folder Structure
`Models` defines records and history, `Data` defines database constraints, `Services` owns the transactional state machine, `tests` covers business rules, and `migrations` documents the schema.

## Security Notes
Passwords are hashed, JWTs expire, roles and ownership are server enforced, EF queries are parameterized, pagination is capped, and transitions plus history entries are atomic. Production should enforce HTTPS, rotate secrets, configure CORS, and use managed storage.

## Known Limitations
This scoped system tracks metadata rather than uploaded document files. Full-text indexing, signatures, retention automation, and enterprise SSO are not included.

## License
MIT
