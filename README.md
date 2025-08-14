# MyDebugConsole

## 项目简介 (Project Description)

MyDebugConsole 是一个用 C# 开发的 Windows Forms 调试控制台应用程序，为开发者提供了一个可视化的日志显示和管理工具。该项目可以作为独立的调试窗口，也可以集成到其他 .NET 应用程序中，用于实时显示和过滤应用程序的日志信息。

MyDebugConsole is a Windows Forms debug console application developed in C#, providing developers with a visual log display and management tool. This project can be used as a standalone debug window or integrated into other .NET applications for real-time display and filtering of application log information.

## 主要功能 (Main Features)

### 🔍 日志分类显示 (Categorized Log Display)
- **普通信息 (Normal)**: 一般的程序运行信息
- **警告信息 (Warning)**: 需要注意的警告消息  
- **错误信息 (Error)**: 程序错误和异常信息

### 🎨 可视化界面 (Visual Interface)
- 每种日志类型都有对应的图标标识
- 支持不同颜色和图标区分消息类型
- 清晰的列表显示和详细信息查看

### 🔧 强大的过滤功能 (Powerful Filtering)
- **类型过滤**: 可以选择显示/隐藏特定类型的日志
- **合并重复**: 自动合并相同的日志消息，显示出现次数
- **实时过滤**: 动态切换过滤条件

### 📋 实用工具 (Utility Features)
- **自动滚动**: 新日志自动滚动到可视区域
- **详细查看**: 点击日志查看完整信息
- **堆栈跟踪**: 可选择是否显示调用堆栈
- **清除功能**: 一键清空所有日志
- **线程安全**: 支持多线程环境下的安全日志记录

## 项目结构 (Project Structure)

```
MyDebugConsole/
├── DebugConsole/                 # 主要的调试控制台库
│   ├── MyConsole.cs             # 主窗体类，实现UI和日志显示逻辑
│   ├── MyConsole.Designer.cs    # 窗体设计文件
│   ├── DebugerWindow.cs         # 静态包装类，提供简单的API接口
│   ├── Program.cs               # 程序入口点
│   └── Resources/               # 图标资源文件
│       ├── error.png           # 错误图标
│       ├── warning.png         # 警告图标
│       └── normal.png          # 普通信息图标
├── WindowsFormsApp1/            # 演示应用程序
│   ├── Form1.cs                # 演示如何使用调试控制台
│   └── ...
└── DebugConsole.sln            # Visual Studio 解决方案文件
```

## 核心类说明 (Core Classes)

### 1. MyConsole 类
主要的窗体类，包含所有的 UI 控件和日志处理逻辑：
- `Log(string msg, MsgType msgType, bool isPrintStack = false)`: 添加日志消息
- 支持实时过滤和消息合并
- 自动滚动和详细信息显示

### 2. DebugerWindow 类
静态包装类，提供简单易用的API：
- `Initialization()`: 初始化调试窗口
- `Log(string msg, bool printStack = false)`: 记录普通日志
- `LogWarning(string msg, bool printStack = false)`: 记录警告日志
- `LogError(string msg, bool printStack = false)`: 记录错误日志
- `Release()`: 释放资源

### 3. MsgType 枚举
定义日志消息类型：
```csharp
public enum MsgType
{
    Warning,    // 警告
    Error,      // 错误
    Normal      // 普通
}
```

## 使用方法 (Usage)

### 基本使用 (Basic Usage)

```csharp
// 初始化调试窗口
DebugerWindow.Initialization();

// 记录不同类型的日志
DebugerWindow.Log("这是一条普通日志");
DebugerWindow.LogWarning("这是一条警告日志");
DebugerWindow.LogError("这是一条错误日志", true); // 包含堆栈跟踪

// 释放资源
DebugerWindow.Release();
```

### 高级使用 (Advanced Usage)

```csharp
// 直接使用 MyConsole 类
var console = new MyConsole();
console.Show();

// 添加日志
console.Log("详细的调试信息", MsgType.Normal);
console.Log("发现潜在问题", MsgType.Warning);
console.Log("发生严重错误", MsgType.Error, true); // 包含堆栈信息
```

## 技术特性 (Technical Features)

- **框架**: .NET Framework 4.0
- **界面**: Windows Forms
- **线程安全**: 支持多线程日志记录
- **内存管理**: 自动清理和资源释放
- **扩展性**: 易于集成到现有项目中

## 适用场景 (Use Cases)

1. **应用程序调试**: 在开发阶段实时查看程序运行状态
2. **日志监控**: 生产环境下的日志实时监控
3. **错误诊断**: 快速定位和分析程序错误
4. **性能分析**: 跟踪程序执行流程和性能问题
5. **集成测试**: 在测试过程中监控程序行为

## 编译和运行 (Build and Run)

1. 打开 Visual Studio
2. 加载 `DebugConsole.sln` 解决方案文件
3. 编译整个解决方案
4. 运行 `WindowsFormsApp1` 查看演示效果

或者直接使用 MSBuild：
```bash
msbuild DebugConsole.sln /p:Configuration=Release
```

## 贡献 (Contributing)

欢迎提交 Issues 和 Pull Requests 来改进这个项目！

Welcome to submit Issues and Pull Requests to improve this project!

## 许可证 (License)

本项目采用开源许可证，详情请查看 LICENSE 文件。

This project is licensed under an open source license. Please see the LICENSE file for details.