# Microsoft.Identity.Abstractions Support Policy

_Last updated May 14, 2025_

## Supported versions
The following table lists Microsoft.Identity.Abstractions versions currently supported and receiving security fixes.

| Major Version | Last Release | Patch Release Date  | Support Phase|End of Support |
| --------------|--------------|--------|------------|--------|
| 9.x           | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Identity.Abstractions.svg?style=flat-square&label=nuget&colorB=00b200)](https://www.nuget.org/packages/Microsoft.Identity.Abstractions/)   |Monthly| Active | Not planned.<br/>✅Supported versions: from 9.0.0 to [![NuGet](https://img.shields.io/nuget/v/Microsoft.Identity.Abstractions.svg?style=flat-square&label=nuget&colorB=00b200)](https://www.nuget.org/packages/Microsoft.Identity.Abstractions/)<br/>⚠️Unsupported versions `< 9.0.0`.|

## Out of support versions
The following table lists Microsoft.Identity.Abstractions versions no longer supported and no longer receiving security fixes.

| Major Version | Latest Patch Version| Patch Release Date | End of Support Date|
| --------------|--------------|--------|--------|
| 8.x           |    8.2.0       | February 14, 2025      | March 31, 2025  |
| 7.x           |    7.2.1       | January 21, 2025       | March 31, 2025  |
| 6.x           |    6.0.0       | June 21, 2024          | March 31, 2025  |
| 5.x           |    5.3.0       | April 22, 2024         | March 31, 2025  |
| 4.x           |    4.1.0       | September 7, 2023      | March 31, 2025  |
| 3.x           |    3.2.1       | May 29, 2023           | March 31, 2025  |
| 2.x           |    2.1.0       | March 12, 2023         | March 31, 2025  |
| 1.x           |    1.2.0       | January 6, 2023        | March 31, 2025  |

## Overview

Every Microsoft product has a lifecycle. The lifecycle begins when a product is released and ends when it's no longer supported. Knowing key dates in this lifecycle helps you make informed decisions about when to upgrade or make other changes to your software. This product is governed by [Microsoft's Modern Lifecycle Policy](https://learn.microsoft.com/en-us/lifecycle/policies/modern).

The Microsoft suite of auth libraries provides comprehensive tools for identity and security token processing in .NET, and non-.NET, applications, including authentication, authorization, token validation, and integration with Entra ID and other IdPs. To provide clarity and predictability for developers, these libraries follow a Long-Term Support (LTS) policy similar in style to the .NET Core/.NET platform LTS story. This policy defines how long each major version of each library is supported, which versions receive updates (especially security fixes), and when older versions are deprecated. The goal is to ensure developers know which version is safe to use and when to upgrade, in alignment with .NET’s own support cadence.

## Support Policy Guiding Principles
The support policy can be summarized by three key rules:
1. **“Last Major Release” Support Window:** For each major version of the library (v5, v6, v7, v8, etc.), only the latest patch release of that major version is officially supported once a new major version is released. This last release of a major version (for example, 7.7.1 for the 7.x branch) will continue to be supported for a grace period of 180 days after the next major (v8.0) comes out.
2. **Deprecation of Older Versions on New Major Release:** When a new major version of the library is released (e.g., 8.0.0), all previous minor/patch versions of the previous major (e.g., 7.0.0 up to 7.7.0) are immediately considered deprecated, only the last patch release of the previous major (e.g., 7.7.1) remains supported during the 180-day overlap or LTS period as described above. Earlier patches in that branch will no longer receive updates. For example, once 8.0.0 is released, the entire 7.x series before 7.7.1 is deprecated. Developers should move to 7.7.1 (the final 7.x release) or upgrade to 8.x for continued support.
3. **Security Fixes Only in Supported Versions:** Security fixes and critical bug fixes will be provided only for the supported versions – namely, the latest patch of the latest major, and in some cases the latest patch of the previous major during the overlap window. Older majors (and any old patch versions) will not receive security updates once they are out of support. This means if a vulnerability is discovered, the team will issue a fix in the current supported release (and possibly the last release of the previous major if still within 180-day), but will not back-port fixes to earlier, deprecated patch versions. In practice, organizations must upgrade to the supported version to get the fix. (For example, a security advisory might instruct users to update to 7.7.1 or 8.x to resolve an issue, as older 7.x builds would not be patched.)
