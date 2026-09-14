# Unity Dave Dive Visual Demo / Unity 戴夫潜水视觉演示

[English](#english) | [中文](#chinese)

---

<a name="english"></a>
## English

### Overview

A Unity URP 2.5D underwater visual demo inspired by Dave the Diver's rendering techniques. This is a **fan recreation** for educational purposes demonstrating underwater atmosphere effects, depth-based fog, god rays, and a mix of 2D sprite characters with 3D environments.

**⚠️ No copyrighted Dave the Diver assets are included.**

### Features

- ✨ **URP (Universal Render Pipeline)** for scalable underwater visuals
- 🌊 **Depth-based fog and color absorption** - turquoise shallows gradually transition to deep azure
- 🌅 **God rays (volumetric light shafts)** with animated scrolling and intensity pulse
- 🎨 **2.5D Hybrid rendering** - 2D pixel art diver sprite living in a 3D environment
- 🏔️ **Terraced reef walls** forming a vertical Blue Hole-style shaft
- 📹 **Perspective side-view camera** following the diver with smooth descent
- 🎮 **Automated 40-60 second descent tour** showcasing different depth zones
- 📊 **Depth HUD** displaying current depth in meters and zone name

### Technical Stack

This demo showcases the same core rendering technologies used in Dave the Diver (according to Mintrocket's Unity case study):

- **Unity 2022.3.19f1 LTS** (compatible with Unity 2022 LTS and Unity 6)
- **Universal Render Pipeline (URP)** v14.0.9
- **Cinemachine** v2.9.7 for camera control
- **TextMeshPro** for UI text rendering
- **Shader Graph** concepts (depth fog, transparent materials)

### Unity Hub Installation

#### Requirements
- Unity Hub 3.x
- Unity 2022.3 LTS or Unity 6 (2022.3.19f1 recommended)

#### Opening the Project

1. **Install Unity Hub**
   - Download from: https://unity.com/download
   - Install Unity Hub following the official installer

2. **Install Unity Editor**
   - Open Unity Hub
   - Go to "Installs" tab
   - Click "Install Editor"
   - Select **Unity 2022.3.19f1 LTS** (or any Unity 2022.3.x LTS version)
   - Include modules: Windows Build Support / Mac Build Support / Linux Build Support (depending on your platform)

3. **Open the Project**
   - In Unity Hub, click "Open" or "Add"
   - Navigate to the `UnityProject` folder in this repository
   - Select the folder and click "Open"
   - Unity will import assets (first import may take 1-2 minutes)

4. **Play the Demo**
   - Once the project loads, look for the "DiveScene" in the Project window under `Assets/Scenes/`
   - Double-click `DiveScene.unity` to open it
   - Click the **Play** button (▶️) at the top center of the Unity Editor
   - The diver will automatically begin descending through the underwater shaft
   - Watch the depth HUD in the top-left showing depth and zone information

### Project Structure

```
UnityProject/
├── Assets/
│   ├── Scenes/
│   │   └── DiveScene.unity          # Main demo scene (set as default)
│   ├── Scripts/
│   │   ├── DiverController.cs       # Auto-descent and diver animation
│   │   ├── DepthHUD.cs             # Depth display UI controller
│   │   ├── UnderwaterFogController.cs # Depth-based fog and color transition
│   │   └── GodRayEffect.cs         # God ray animation
│   ├── Materials/
│   │   ├── ReefMaterial.mat        # Reef wall material (URP/Lit)
│   │   └── GodRayMaterial.mat      # Transparent god ray material
│   ├── Textures/
│   │   └── DiverSprite.png         # Pixel art diver sprite (CC0)
│   ├── Settings/
│   │   ├── UniversalRP-HighQuality.asset  # URP pipeline asset
│   │   └── URPRenderer.asset              # URP renderer settings
│   └── Prefabs/                    # (Empty - room for expansion)
├── ProjectSettings/                # Unity project configuration
└── Packages/
    └── manifest.json               # Package dependencies (URP, Cinemachine, etc.)
```

### How It Maps to Dave the Diver's URP Stack

Based on Mintrocket's Unity case study, this demo recreates key rendering techniques:

| **Dave the Diver Technique** | **Implementation in This Demo** |
|------------------------------|--------------------------------|
| URP for underwater rendering | ✅ `UniversalRP-HighQuality.asset` pipeline |
| Shader Graph for stylized effects | ✅ Depth fog in `UnderwaterFogController.cs`, transparent god ray materials |
| Cinemachine for camera control | ✅ Main Camera follows diver with side-view perspective (can be extended with Cinemachine Virtual Camera) |
| 2D sprites in 3D environment | ✅ `DiverController` uses `SpriteRenderer` in 3D world space |
| Depth-based color absorption | ✅ Fog color lerps from shallow turquoise to deep azure based on Y position |
| Volumetric god rays | ✅ Animated transparent stretched cubes with pulsing opacity |
| Vertical shaft design | ✅ Left/right reef walls forming a ~40 unit wide shaft descending 120+ meters |

### Customization Tips

- **Adjust descent speed**: Modify `DiverController.descentSpeed` in the Inspector
- **Change color gradient**: Edit `UnderwaterFogController` shallow/deep colors
- **Add more god rays**: Duplicate the `GodRay1` object and change position/rotation
- **Extend the shaft**: Scale the `LeftWall` and `RightWall` GameObjects vertically
- **Replace diver sprite**: Swap out `DiverSprite.png` with your own pixel art (remember to keep it CC0 or create your own)

### Performance Notes

- Targets 60 FPS on mid-range hardware
- URP rendering optimized for scalability
- Fog is CPU-based (camera script) - could be moved to post-processing volume for better performance
- God rays use simple transparent geometry - consider using URP's volumetric fog for production

### Recording Limitations on Cloud VM

This project was built on a headless cloud environment. If you cannot record a GUI video walkthrough:
- The project is fully functional when opened in Unity Editor
- Take screenshots in Play mode (Game view)
- Use Unity Recorder package for video capture on a local machine
- Batch-mode screenshots can be captured via command line if needed

### Known Limitations

- No interactive controls (auto-tour only)
- Simplified god ray implementation (geometric shapes vs. true volumetric)
- No audio (to avoid copyright issues)
- Single scene demo (no gameplay systems)
- Camera doesn't use Cinemachine Virtual Camera yet (can be upgraded)

### Future Enhancements

- Add Cinemachine Virtual Camera with composition rules
- Implement Shader Graph for caustics (animated underwater light patterns)
- Add particle systems for bubbles and marine snow
- Create URP post-processing volume for bloom and color grading
- Add more depth zones with different environmental props
- Implement manual controls (WASD movement)

### License

This project is a fan-made educational demo. All code and assets (except Unity packages) are provided as-is for learning purposes.

- **Diver sprite**: Custom pixel art (CC0 equivalent)
- **Scripts**: Free to use and modify
- **Dave the Diver** is a trademark of MINTROCKET. This project is not affiliated with or endorsed by MINTROCKET.

### References

- [Unity Case Study: Dave the Diver](https://unity.com/case-studies/dave-the-diver)
- [Unity URP Documentation](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@latest)
- [Cinemachine Documentation](https://docs.unity3d.com/Packages/com.unity.cinemachine@latest)

---

<a name="chinese"></a>
## 中文

### 概述

一个受《戴夫潜水员》渲染技术启发的 Unity URP 2.5D 水下视觉演示。这是一个**粉丝重制**教育项目,展示水下氛围效果、基于深度的雾效、上帝光线,以及 2D 精灵角色与 3D 环境的混合。

**⚠️ 不包含任何《戴夫潜水员》的版权资源。**

### 特性

- ✨ **URP (通用渲染管线)** 用于可扩展的水下视觉效果
- 🌊 **基于深度的雾效和颜色吸收** - 浅绿色浅水区逐渐过渡到深蓝色深海
- 🌅 **上帝光线 (体积光束)** 带有动画滚动和强度脉冲
- 🎨 **2.5D 混合渲染** - 2D 像素艺术潜水员精灵生活在 3D 环境中
- 🏔️ **梯田式礁石墙** 形成垂直蓝洞风格的竖井
- 📹 **透视侧视角相机** 跟随潜水员平滑下潜
- 🎮 **40-60 秒自动下潜游览** 展示不同深度区域
- 📊 **深度 HUD** 显示当前深度(米)和区域名称

### 技术栈

此演示展示了《戴夫潜水员》使用的核心渲染技术(根据 Mintrocket 的 Unity 案例研究):

- **Unity 2022.3.19f1 LTS** (兼容 Unity 2022 LTS 和 Unity 6)
- **通用渲染管线 (URP)** v14.0.9
- **Cinemachine** v2.9.7 用于相机控制
- **TextMeshPro** 用于 UI 文本渲染
- **Shader Graph** 概念(深度雾效、透明材质)

### Unity Hub 安装

#### 要求
- Unity Hub 3.x
- Unity 2022.3 LTS 或 Unity 6(推荐 2022.3.19f1)

#### 打开项目

1. **安装 Unity Hub**
   - 下载地址: https://unity.com/download
   - 按照官方安装程序安装 Unity Hub

2. **安装 Unity 编辑器**
   - 打开 Unity Hub
   - 转到"Installs"(安装)选项卡
   - 点击"Install Editor"(安装编辑器)
   - 选择 **Unity 2022.3.19f1 LTS**(或任何 Unity 2022.3.x LTS 版本)
   - 包含模块: Windows Build Support / Mac Build Support / Linux Build Support(取决于您的平台)

3. **打开项目**
   - 在 Unity Hub 中,点击"Open"(打开)或"Add"(添加)
   - 导航到此仓库中的 `UnityProject` 文件夹
   - 选择文件夹并点击"Open"(打开)
   - Unity 将导入资源(首次导入可能需要 1-2 分钟)

4. **播放演示**
   - 项目加载后,在 Project 窗口的 `Assets/Scenes/` 下查找"DiveScene"
   - 双击 `DiveScene.unity` 打开它
   - 点击 Unity 编辑器顶部中央的 **Play** 按钮 (▶️)
   - 潜水员将自动开始通过水下竖井下潜
   - 观察左上角显示深度和区域信息的深度 HUD

### 项目结构

```
UnityProject/
├── Assets/
│   ├── Scenes/
│   │   └── DiveScene.unity          # 主演示场景(设为默认)
│   ├── Scripts/
│   │   ├── DiverController.cs       # 自动下潜和潜水员动画
│   │   ├── DepthHUD.cs             # 深度显示 UI 控制器
│   │   ├── UnderwaterFogController.cs # 基于深度的雾效和颜色过渡
│   │   └── GodRayEffect.cs         # 上帝光线动画
│   ├── Materials/
│   │   ├── ReefMaterial.mat        # 礁石墙材质 (URP/Lit)
│   │   └── GodRayMaterial.mat      # 透明上帝光线材质
│   ├── Textures/
│   │   └── DiverSprite.png         # 像素艺术潜水员精灵 (CC0)
│   ├── Settings/
│   │   ├── UniversalRP-HighQuality.asset  # URP 管线资源
│   │   └── URPRenderer.asset              # URP 渲染器设置
│   └── Prefabs/                    # (空 - 预留扩展空间)
├── ProjectSettings/                # Unity 项目配置
└── Packages/
    └── manifest.json               # 包依赖项 (URP, Cinemachine 等)
```

### 如何映射到《戴夫潜水员》的 URP 技术栈

基于 Mintrocket 的 Unity 案例研究,此演示重现了关键渲染技术:

| **《戴夫潜水员》技术** | **此演示中的实现** |
|---------------------|------------------|
| URP 用于水下渲染 | ✅ `UniversalRP-HighQuality.asset` 管线 |
| Shader Graph 用于风格化效果 | ✅ `UnderwaterFogController.cs` 中的深度雾效,透明上帝光线材质 |
| Cinemachine 用于相机控制 | ✅ 主相机以侧视角跟随潜水员(可扩展为 Cinemachine Virtual Camera) |
| 3D 环境中的 2D 精灵 | ✅ `DiverController` 在 3D 世界空间中使用 `SpriteRenderer` |
| 基于深度的颜色吸收 | ✅ 雾效颜色根据 Y 位置从浅绿色插值到深蓝色 |
| 体积上帝光线 | ✅ 动画透明拉伸立方体,带脉冲不透明度 |
| 垂直竖井设计 | ✅ 左/右礁石墙形成约 40 单位宽的竖井,下潜 120+ 米 |

### 自定义提示

- **调整下潜速度**: 在 Inspector 中修改 `DiverController.descentSpeed`
- **更改颜色渐变**: 编辑 `UnderwaterFogController` 的浅/深颜色
- **添加更多上帝光线**: 复制 `GodRay1` 对象并更改位置/旋转
- **延长竖井**: 垂直缩放 `LeftWall` 和 `RightWall` GameObjects
- **替换潜水员精灵**: 用您自己的像素艺术替换 `DiverSprite.png`(记得保持 CC0 或创建自己的)

### 性能说明

- 目标是在中端硬件上达到 60 FPS
- URP 渲染已针对可扩展性进行优化
- 雾效基于 CPU(相机脚本) - 可以移至后处理体积以获得更好的性能
- 上帝光线使用简单透明几何体 - 考虑使用 URP 的体积雾进行生产

### 云 VM 上的录制限制

此项目在无头云环境中构建。如果您无法录制 GUI 视频演练:
- 项目在 Unity 编辑器中打开时完全正常工作
- 在 Play 模式下截取屏幕截图(Game 视图)
- 在本地机器上使用 Unity Recorder 包进行视频捕获
- 如果需要,可以通过命令行捕获批处理模式屏幕截图

### 已知限制

- 没有交互式控制(仅自动游览)
- 简化的上帝光线实现(几何形状 vs. 真实体积)
- 没有音频(为避免版权问题)
- 单场景演示(没有游戏系统)
- 相机尚未使用 Cinemachine Virtual Camera(可以升级)

### 未来增强

- 添加带有构图规则的 Cinemachine Virtual Camera
- 实现 Shader Graph 焦散效果(动画水下光图案)
- 为气泡和海洋雪添加粒子系统
- 创建 URP 后处理体积以实现辉光和颜色分级
- 添加更多深度区域和不同的环境道具
- 实现手动控制(WASD 移动)

### 许可证

此项目是一个粉丝制作的教育演示。所有代码和资源(Unity 包除外)按原样提供用于学习目的。

- **潜水员精灵**: 自定义像素艺术(CC0 等效)
- **脚本**: 可自由使用和修改
- **《戴夫潜水员》** 是 MINTROCKET 的商标。此项目不隶属于 MINTROCKET,也未获得其认可。

### 参考资料

- [Unity 案例研究:《戴夫潜水员》](https://unity.com/case-studies/dave-the-diver)
- [Unity URP 文档](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@latest)
- [Cinemachine 文档](https://docs.unity3d.com/Packages/com.unity.cinemachine@latest)

---

## Repository Structure / 仓库结构

```
.
├── README.md                       # This file / 本文件
├── .gitignore                     # Unity gitignore
└── UnityProject/                  # Unity project root / Unity 项目根目录
    ├── Assets/                    # Game assets / 游戏资源
    ├── ProjectSettings/           # Project configuration / 项目配置
    └── Packages/                  # Package dependencies / 包依赖
```

## Quick Start (TL;DR) / 快速开始

**English**: Install Unity Hub → Install Unity 2022.3 LTS → Open `UnityProject` folder → Open `DiveScene.unity` → Press Play ▶️

**中文**: 安装 Unity Hub → 安装 Unity 2022.3 LTS → 打开 `UnityProject` 文件夹 → 打开 `DiveScene.unity` → 按 Play ▶️

---

**Enjoy the dive! / 享受潜水!** 🌊🤿
