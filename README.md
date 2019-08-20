# Active Logic

A library for everyday case logic, solving problems where *time* is an essential element: game development, game AIs, interactive applications and control systems.

Active Logic implements discrete, iterative control. It is grounded in [Behavior trees](https://en.wikipedia.org/wiki/Behavior_tree_(artificial_intelligence,_robotics_and_control)) (BT) and many-valued logic.

[![Build Status](https://travis-ci.com/active-logic/activelogic-cs.svg?branch=master)](https://travis-ci.com/active-logic/activelogic-cs)

## License information

- GNU Affero GPL v3.0. TLDR, use the software freely, *provided derivative works are free, open source*.
- Will be free for: personal and educational uses, indies and early stage startups - pending license.
- Business licenses (non free) - pending license.
- An augmented version of the library will be sold through the Unity Asset Store; pending submission.

## Introduction

BT implementations available for general purpose languages typically involve:

**Explicit data structures** - This approach is flexible but the resulting programs may be harder to read, slower, and definitely require more memory.

**Visual programming** - This simply doesn't suit everybody's taste. Rather than a visual tool integrating existing code via complex interfaces and/or blackboards, some of us prefer writing computer programs.

Active Logic seamlessly integrates with the host language:

```cs
class Duelist : UTask{

    float health = 100;

    Transform threat => null;

    override public status Step() => Attack() || Defend() || Retreat();

    status Attack() => threat && health > 25
        ? Engage(threat) && Cooldown(1.0f)?[ Strike(threat) ]
        : fail(log && $"No threat, or low hp ({health})");

    pending   Defend()                  => + undef();
    status    Engage(Transform threat)  =>   undef();
    impending Retreat()                 => - undef();
    action    Strike(Transform threat)  =>   @void();

}
```

Active Logic programs look mundane: no callbacks, lambdas or co-routines. The temporal dimension is factored into the `status` type; benefits:

- **Simplicity**: Active Logic programs have a clear and concise, inductive structure.
- **Resilience**: statelessness ensures that, confronted with changing conditions, active logic programs respond in a timely, predictable manner.

## Language support

While Active Logic programs do look simple, offering a clean, concise syntax without compromising performance and thread safety is not.

The library requires C# 7.2; uniquely (if indirectly), C# permits overloading the short-circuit operators. Other languages (Notably: C, C++, Python, Rust, Swift) may not have this (or leave shorting behind).

C++ and Swift versions are being worked on. For some languages, direct support (upgrade the language) is considered.

C# back-ports are considered; no ETA.

Whether you're hoping for a C# back-port, or would like support for another language, scratch an itch:
- Open/upvote an issue, and motivate your request
- Submit a diff (an incomplete diff is better than just asking for help)

## Where next?

- Download the library - **Pending verify compat with .NET Core, Mono**
- Read the [Quick start Guide](Doc/QuickStart.md)
- Check the [API reference](Doc/Reference/Overview.md)
- For questions pertaining game development, reach the [discord forum](https://discord.gg/Jn9TQRR).
- For other inquiries, open an issue and we'll be in touch.