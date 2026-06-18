# Anti-Cheat Detection Analysis

## How Anti-Cheat Systems Detect Wallhacks

### Detection Method 1: Memory Scanning
Anti-cheat engines (EAC, BattlEye) scan process memory for:
- Suspicious DLLs injected into game process
- Hooks into rendering or input systems
- Modified game object values

**RoR2 Status**: Does NOT have kernel-level anti-cheat. BepInEx mods are technically detectable by:
- Scanning for BepInEx library files
- Checking for modified game DLLs

**Mitigation**: This mod is **offline only** — no network activity means no anti-cheat server to report to.

---

### Detection Method 2: Behavioral Analysis
Anti-cheat watches for:
- **Impossible aim** - Inhuman tracking speed or accuracy
- **Wall penetration** - Hitting enemies through walls
- **Information advantage** - Reacting to enemies before they're visible

**This Mod's Risk**: 
- Aim-assist smoothing can mimic human aim if tuned carefully
- Overlay alone doesn't guarantee hits (aim-assist is optional)
- Perfect detection is hard, but skilled players notice unnatural behavior

---

### Detection Method 3: Net Code Analysis
Server checks:
- Packet timing anomalies
- Impossible shot trajectories
- Client-side vs server-side disagreements

**RoR2 Status**: Multiplayer uses server authority. However, **this mod is offline only**, so no server communication occurs.

---

## Why This Mod is Safe for Offline Play

1. **No Network Traffic** - Can't be detected by server-side checks
2. **No Unfair Advantage** - Single-player only; doesn't affect other players
3. **No Game Modification** - Overlay is informational, not cheating (in offline context)
4. **No Balance Breaking** - Difficulty and progression work normally

---

## If Used in Multiplayer (Not Recommended)

- **Instant Detection**: BepInEx presence would likely be flagged
- **Account Ban Risk**: EAC/anti-cheat could ban account on sight
- **Fair Play Violation**: Using aim-assist in PvP is cheating

**Recommendation**: Keep this mod for offline/solo runs only.

---

## How You'd Be Caught (If You Tried Online)

| Method | Detection Level | Time to Detect |
|--------|-----------------|-----------------|
| Memory scan for BepInEx | Very High | On game launch |
| Behavioral analysis | Medium | First multiplayer match |
| Server-side checks | High | First suspicious shot |

---

## Technical Indicators This Mod Creates

### Memory Signature
```
"BepInEx" string in process memory
Hooked game DLLs (Assembly-CSharp)
Injected methods in CharacterBody class
```

### Runtime Indicators
```
Unusual camera manipulation patterns
EntityDetector polling all CharacterBody objects rapidly
Overlay rendering system not present in vanilla RoR2
```

### Behavioral Indicators
```
Frame-perfect aim tracking
Shots landing through walls (if aim-assist too aggressive)
Inhuman reaction time to distant enemies
```

---

## Lessons for Anti-Cheat Bypass Prevention

This analysis teaches why modern anti-cheat is hard to bypass:

1. **Multiple Detection Layers** - Can't hide from all of them
2. **Server Authority** - Even if client hacks, server validates
3. **Behavioral Detection** - Hard to make cheating look human
4. **Kernel-Level Monitoring** - Can detect drivers/hooks before user-mode code runs

