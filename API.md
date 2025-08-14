# API 文档 (API Documentation)

## DebugerWindow 类 (DebugerWindow Class)

`DebugerWindow` 是调试控制台的主要API类，提供静态方法来管理调试窗口和记录日志。

### 静态方法 (Static Methods)

#### Initialization()
初始化调试控制台窗口。

```csharp
public static void Initialization()
```

**说明**: 
- 创建并显示调试控制台窗口
- 如果窗口已存在，会先释放旧窗口再创建新窗口
- 线程安全

**示例**:
```csharp
DebugerWindow.Initialization();
```

---

#### Release()
释放调试控制台窗口和相关资源。

```csharp
public static void Release()
```

**说明**:
- 关闭调试控制台窗口
- 释放所有相关资源
- 建议在程序退出时调用

**示例**:
```csharp
DebugerWindow.Release();
```

---

#### Log(string msg, bool printStack = false)
记录普通日志消息。

```csharp
public static void Log(string msg, bool printStack = false)
```

**参数**:
- `msg` (string): 日志消息内容
- `printStack` (bool, 可选): 是否包含调用堆栈信息，默认为 false

**示例**:
```csharp
DebugerWindow.Log("这是一条普通日志");
DebugerWindow.Log("包含堆栈的日志", true);
```

---

#### LogWarning(string msg, bool printStack = false)
记录警告日志消息。

```csharp
public static void LogWarning(string msg, bool printStack = false)
```

**参数**:
- `msg` (string): 警告消息内容
- `printStack` (bool, 可选): 是否包含调用堆栈信息，默认为 false

**示例**:
```csharp
DebugerWindow.LogWarning("这是一条警告");
DebugerWindow.LogWarning("包含堆栈的警告", true);
```

---

#### LogError(string msg, bool printStack = false)
记录错误日志消息。

```csharp
public static void LogError(string msg, bool printStack = false)
```

**参数**:
- `msg` (string): 错误消息内容
- `printStack` (bool, 可选): 是否包含调用堆栈信息，默认为 false

**示例**:
```csharp
DebugerWindow.LogError("这是一条错误");
DebugerWindow.LogError("包含堆栈的错误", true);
```

---

## MyConsole 类 (MyConsole Class)

`MyConsole` 是调试控制台的窗体类，继承自 `Form`，提供更直接的控制。

### 构造函数 (Constructor)

```csharp
public MyConsole()
```

创建一个新的调试控制台窗体实例。

### 公共方法 (Public Methods)

#### Log(string msg, MsgType msgType, bool isPrintStack = false)
向控制台添加日志消息。

```csharp
public void Log(string msg, MsgType msgType, bool isPrintStack = false)
```

**参数**:
- `msg` (string): 日志消息内容
- `msgType` (MsgType): 消息类型枚举
- `isPrintStack` (bool, 可选): 是否包含调用堆栈信息，默认为 false

**示例**:
```csharp
var console = new MyConsole();
console.Show();
console.Log("普通消息", MsgType.Normal);
console.Log("警告消息", MsgType.Warning);
console.Log("错误消息", MsgType.Error, true);
```

---

## MsgType 枚举 (MsgType Enumeration)

定义日志消息的类型。

```csharp
public enum MsgType
{
    Warning,    // 警告消息
    Error,      // 错误消息
    Normal      // 普通消息
}
```

### 枚举值 (Enumeration Values)

- **Warning**: 警告类型消息，通常用于提醒潜在问题
- **Error**: 错误类型消息，用于记录程序错误和异常
- **Normal**: 普通类型消息，用于一般的程序运行信息

---

## 线程安全性 (Thread Safety)

### 安全的方法 (Thread-Safe Methods)
- `DebugerWindow.Initialization()`
- `DebugerWindow.Release()`
- `DebugerWindow.Log()`
- `DebugerWindow.LogWarning()`
- `DebugerWindow.LogError()`
- `MyConsole.Log()`

### 使用说明 (Usage Notes)
- 所有日志方法都是线程安全的，可以在多线程环境中安全调用
- 内部使用了 `lock` 机制确保线程安全
- 设置了 `CheckForIllegalCrossThreadCalls = false` 以支持跨线程操作UI

**多线程示例**:
```csharp
// 在不同线程中安全调用
Task.Run(() => DebugerWindow.Log("来自线程1的消息"));
Task.Run(() => DebugerWindow.LogWarning("来自线程2的警告"));
Task.Run(() => DebugerWindow.LogError("来自线程3的错误"));
```

---

## 界面控件说明 (UI Controls Description)

### 主要控件 (Main Controls)

#### 日志列表 (DebugLst - ListBox)
- 显示所有日志消息
- 支持自定义绘制，显示图标和文本
- 自动滚动到最新消息
- 点击选择查看详细信息

#### 过滤复选框 (Filter CheckBoxes)
- **ErrorCb**: 控制是否显示错误消息
- **WarringCb**: 控制是否显示警告消息
- **NormalCb**: 控制是否显示普通消息
- **CombineCb**: 控制是否合并重复消息

#### 操作按钮 (Action Buttons)
- **CleanBtn**: 清空所有日志消息

#### 详细信息文本框 (DetailTb - TextBox)
- 显示选中日志消息的完整内容
- 只读文本框，支持多行显示

### 事件处理 (Event Handlers)

```csharp
// 过滤条件改变事件
private void ErrorCb_CheckedChanged(object sender, EventArgs e)
private void WarringCb_CheckedChanged(object sender, EventArgs e)
private void NormalCb_CheckedChanged(object sender, EventArgs e)
private void CombineCb_CheckedChanged(object sender, EventArgs e)

// 清空按钮点击事件
private void CleanBtn_Click(object sender, EventArgs e)

// 列表选择改变事件
private void DebugLst_SelectedIndexChanged(object sender, EventArgs e)
```

---

## 资源文件 (Resources)

### 图标资源 (Icon Resources)
- **error.png**: 错误消息图标（红色）
- **normal.png**: 普通消息图标（蓝色）
- **warring.png**: 警告消息图标（黄色）

### 使用方式 (Usage)
图标作为嵌入资源存储在程序集中，通过 `Resources` 类访问：

```csharp
errorIcon = Resources.error;
normalIcon = Resources.normal;
warringIcon = Resources.warring;
```

---

## 错误处理 (Error Handling)

### 空引用检查 (Null Reference Check)
所有静态方法都会检查调试控制台实例是否为空：

```csharp
if (m_inst != null)
{
    // 执行日志操作
}
else
{
    Console.WriteLine("null refrence for debuger");
}
```

### 异常安全 (Exception Safety)
- 所有公共方法都有适当的异常处理
- 不会因为日志操作导致主程序崩溃
- 线程安全的资源管理