# Thunderstore Installation Guide

## For Local Use (Recommended for Development)

### Option 1: Copy DLL Directly
1. Build the project in Visual Studio (Release mode)
2. Navigate to: `RoR2Omniscience/bin/Release/RoR2Omniscience.dll`
3. Copy the DLL to: `D:\SteamLibrary\steamapps\common\Risk of Rain 2\BepInEx\plugins\`
4. Launch RoR2 and test

### Option 2: Use Thunderstore Locally
1. Create a folder structure:
   ```
   RoR2Omniscience/
   ├── plugins/
   │   └── RoR2Omniscience.dll
   ├── manifest.json
   ├── README.md
   └── icon.png
   ```

2. Build your DLL and place it in `plugins/`
3. Open Thunderstore Mod Manager
4. Drag and drop the `RoR2Omniscience` folder into the mod manager
5. Enable the mod and launch

---

## Troubleshooting

**Issue: DLL not loading**
- Check that BepInEx is installed in RoR2
- Verify the DLL is in the correct `BepInEx/plugins/` folder
- Check BepInEx console for error messages

**Issue: Missing game DLL references**
- Open `.csproj` and verify paths match your RoR2 installation:
  ```
  D:\SteamLibrary\steamapps\common\Risk of Rain 2\Risk of Rain 2_Data\Managed\
  ```

**Issue: Overlay not showing**
- Press M for menu
- Press F1 to enable overlay
- Check game console for errors

---

## File Structure Explained

```
ror2-omniscience/
├── RoR2Omniscience/              # Main C# project folder
│   ├── OmnisciencePlugin.cs      # BepInEx entry point
│   ├── OmniscienceManager.cs     # Main controller
│   ├── RoR2Omniscience.csproj    # Project config (has your paths)
│   └── Systems/
│       ├── EntityDetector.cs
│       ├── TargetSelector.cs
│       ├── OverlayRenderer.cs
│       ├── AimAssistSystem.cs
│       └── MenuSystem.cs
├── RoR2Omniscience.sln           # Visual Studio solution
├── manifest.json                 # Thunderstore metadata
├── icon.png                       # Mod icon
├── README.md                      # Main docs
├── CHANGELOG.md                   # Version history
├── DEVJOURNAL.md                  # Learning notes
└── ANTICHEAT.md                   # Security analysis
```

---

## Next Steps

1. **Build the DLL** → Visual Studio �� Build → Release
2. **Test locally** → Copy DLL to BepInEx/plugins
3. **Iterate** → Make changes, rebuild, test
4. **When ready to release** → Package everything and upload to Thunderstore
