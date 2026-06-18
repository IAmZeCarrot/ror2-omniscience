# Development Journal

## Week 1: Project Setup & Core Architecture

### What I Learned

- **Game Object Model**: RoR2 uses `CharacterBody` as the base class for all living entities (players, enemies, bosses). Each has position, health, team affiliation, and visual representation.
- **BepInEx Hooks**: Mods hook into game loops via `On.RoR2.Stage.RawUpdate` or similar delegates. This runs every frame before game logic.
- **Rendering in Unity**: Overlays require `OnGUI()` callbacks or direct camera manipulation. UI elements render in screen space.
- **Entity Detection**: Can iterate through `CharacterBody.readOnlyInstancesList` to find all entities without performance impact.

### Technical Hurdles Encountered

1. **Finding the Right Hook Point**
   - Problem: Need to run every frame, but hooks can run at wrong time in frame pipeline
   - Solution: Use `On.RoR2.Stage.RawUpdate` which runs at frame start before game logic

2. **Accessing Entity Data**
   - Problem: Some entity properties are private or protected
   - Solution: Use reflection or public accessors like `CharacterBody.healthComponent`

3. **Screen Projection**
   - Problem: World coordinates don't translate directly to screen coordinates
   - Solution: Use `Camera.main.WorldToScreenPoint()` to convert 3D positions to 2D screen space

### Code Structure

```
RoR2Omniscience/
├── OmnisciencePlugin.cs          # BepInEx entry point
├── OmniscienceManager.cs         # Main mod logic
├── Systems/
│   ├── EntityDetector.cs         # Find entities
│   ├── OverlayRenderer.cs        # Draw UI
│   ├── TargetSelector.cs         # Pick closest enemy
│   └── AimAssist.cs              # Smooth aiming
└── Utilities/
    └── GameUtils.cs              # Helper functions
```

### Next Week

- Implement entity detection and filtering
- Build overlay rendering system
- Create target selection algorithm
- Document all APIs used

