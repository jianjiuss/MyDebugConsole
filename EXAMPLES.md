# 使用示例 (Usage Examples)

## 示例1：基本集成 (Example 1: Basic Integration)

### 在你的项目中添加调试控制台 (Adding Debug Console to Your Project)

```csharp
using DebugConsole;

class Program
{
    static void Main()
    {
        // 1. 初始化调试控制台
        DebugerWindow.Initialization();
        
        // 2. 你的主程序逻辑
        RunYourApplication();
        
        // 3. 程序结束时释放资源
        DebugerWindow.Release();
    }
    
    static void RunYourApplication()
    {
        try
        {
            DebugerWindow.Log("程序开始运行");
            
            // 模拟一些操作
            ProcessData();
            
            DebugerWindow.Log("程序运行完成");
        }
        catch (Exception ex)
        {
            DebugerWindow.LogError($"程序运行出错: {ex.Message}", true);
        }
    }
    
    static void ProcessData()
    {
        DebugerWindow.Log("开始处理数据");
        
        // 模拟警告情况
        if (SomeCondition())
        {
            DebugerWindow.LogWarning("检测到潜在的性能问题");
        }
        
        // 模拟错误情况
        if (ErrorCondition())
        {
            DebugerWindow.LogError("数据处理失败", true);
        }
        
        DebugerWindow.Log("数据处理完成");
    }
}
```

## 示例2：Web 应用集成 (Example 2: Web Application Integration)

```csharp
public class WebApiController : ApiController
{
    static WebApiController()
    {
        // 在应用启动时初始化调试控制台
        DebugerWindow.Initialization();
    }
    
    [HttpGet]
    public IHttpActionResult GetData(int id)
    {
        DebugerWindow.Log($"接收到请求: GetData, ID={id}");
        
        try
        {
            var data = DataService.GetById(id);
            if (data == null)
            {
                DebugerWindow.LogWarning($"未找到ID为{id}的数据");
                return NotFound();
            }
            
            DebugerWindow.Log($"成功返回数据: ID={id}");
            return Ok(data);
        }
        catch (Exception ex)
        {
            DebugerWindow.LogError($"获取数据时发生错误: {ex.Message}", true);
            return InternalServerError(ex);
        }
    }
}
```

## 示例3：多线程环境 (Example 3: Multi-threaded Environment)

```csharp
class MultiThreadExample
{
    public static void Main()
    {
        DebugerWindow.Initialization();
        
        // 创建多个线程
        var tasks = new Task[5];
        
        for (int i = 0; i < 5; i++)
        {
            int threadId = i;
            tasks[i] = Task.Run(() => WorkerThread(threadId));
        }
        
        Task.WaitAll(tasks);
        
        DebugerWindow.Log("所有线程完成工作");
        
        Console.ReadKey(); // 保持窗口打开
        DebugerWindow.Release();
    }
    
    static void WorkerThread(int threadId)
    {
        for (int i = 0; i < 10; i++)
        {
            DebugerWindow.Log($"线程 {threadId}: 执行任务 {i}");
            
            // 模拟一些工作
            Thread.Sleep(Random.Shared.Next(100, 500));
            
            if (i == 5)
            {
                DebugerWindow.LogWarning($"线程 {threadId}: 到达中间检查点");
            }
        }
        
        DebugerWindow.Log($"线程 {threadId}: 工作完成");
    }
}
```

## 示例4：自定义日志类 (Example 4: Custom Logger Class)

```csharp
public static class Logger
{
    private static bool _isInitialized = false;
    
    public static void Initialize()
    {
        if (!_isInitialized)
        {
            DebugerWindow.Initialization();
            _isInitialized = true;
            Info("日志系统已初始化");
        }
    }
    
    public static void Info(string message)
    {
        DebugerWindow.Log($"[INFO] {DateTime.Now:HH:mm:ss} - {message}");
    }
    
    public static void Warning(string message)
    {
        DebugerWindow.LogWarning($"[WARNING] {DateTime.Now:HH:mm:ss} - {message}");
    }
    
    public static void Error(string message, Exception ex = null)
    {
        var errorMessage = $"[ERROR] {DateTime.Now:HH:mm:ss} - {message}";
        if (ex != null)
        {
            errorMessage += $"\n异常信息: {ex.Message}";
        }
        DebugerWindow.LogError(errorMessage, ex != null);
    }
    
    public static void Debug(string message)
    {
        #if DEBUG
        DebugerWindow.Log($"[DEBUG] {DateTime.Now:HH:mm:ss} - {message}");
        #endif
    }
    
    public static void Shutdown()
    {
        if (_isInitialized)
        {
            Info("日志系统正在关闭");
            DebugerWindow.Release();
            _isInitialized = false;
        }
    }
}

// 使用示例
class Program
{
    static void Main()
    {
        Logger.Initialize();
        
        Logger.Info("应用程序启动");
        Logger.Debug("这是调试信息");
        Logger.Warning("这是警告信息");
        
        try
        {
            // 一些可能出错的代码
            throw new InvalidOperationException("示例异常");
        }
        catch (Exception ex)
        {
            Logger.Error("操作失败", ex);
        }
        
        Logger.Shutdown();
    }
}
```

## 控制台功能说明 (Console Features)

### 1. 过滤功能 (Filtering)
- **Error**: 勾选显示错误消息
- **Warning**: 勾选显示警告消息  
- **Normal**: 勾选显示普通消息
- **Combine**: 勾选合并相同的消息

### 2. 操作按钮 (Action Buttons)
- **Clean**: 清空所有日志消息
- 消息列表会自动滚动到最新消息

### 3. 详细信息 (Details)
- 点击任何日志消息可以在下方文本框中查看完整内容
- 支持堆栈跟踪信息的显示

### 4. 图标说明 (Icons)
- 🔴 红色圆圈: 错误消息
- 🟡 黄色三角: 警告消息  
- 🔵 蓝色圆圈: 普通消息

## 性能建议 (Performance Tips)

1. **生产环境**: 在生产环境中可以通过配置决定是否启用调试控制台
2. **消息限制**: 对于高频日志，考虑添加消息数量限制
3. **异步日志**: 对于性能敏感的应用，可以考虑异步记录日志
4. **资源释放**: 确保在应用程序退出时调用 `Release()` 方法

```csharp
// 生产环境配置示例
#if DEBUG
    DebugerWindow.Initialization();
#endif

// 异步日志示例
Task.Run(() => DebugerWindow.Log("异步日志消息"));
```