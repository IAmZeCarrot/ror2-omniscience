# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [1.0.0] - 2026-06-18

### Added
- Initial release
- Entity detection system (find all enemies, allies, items)
- Real-time overlay with entity info (health, distance, name)
- Target selector (identify closest visible enemy)
- Aim-assist system (smooth aiming toward targets)
- Toggle menu system (M key)
- Keyboard controls (F1, F2, F3 for toggling features)
- Debug info display (FPS, entity count)
- BepInEx/Thunderstore mod structure
- Documentation (README, DEVJOURNAL, ANTICHEAT analysis)

### Known Issues
- Aim-assist may need tuning for different weapon types
- Overlay text can overlap if too many entities present
- No configuration file yet (hardcoded smoothing speed)

### Future Work
- Configuration system (JSON settings file)
- Better overlay layout (sorting, filtering by type)
- Screen edge indicators for off-screen enemies
- Performance optimization for late-game entity counts
- Advanced targeting filters (by health %, by type, etc.)
