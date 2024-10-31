open System
open System.Net.Http
open System.Threading.Tasks

let fetchUrlAsync (url: string) : Async<string> =
    async {
        use client = new HttpClient()
        let! response = client.GetStringAsync(url) |> Async.AwaitTask
        return response
    }

let runFetch() =
    let urls = ["https://www.example.com"; "https://www.google.com"]
    let tasks = urls |> List.map fetchUrlAsync
    let results = Async.Parallel tasks |> Async.RunSynchronously
    results |> Array.iter (printfn "%s")

runFetch()

let computeSquare x =
    printfn "Computing square of %d" x
    x * x

let parallelComputation() =
    let numbers = [1; 2; 3; 4; 5]
    let tasks = numbers |> List.map (fun n -> Task.Run(fun () -> computeSquare n))
    Task.WaitAll(tasks |> List.toArray)
    
parallelComputation()

let runWithMutex() =
    let mutex = new Mutex(false, "GlobalMutexExample")
    try
        printfn "Attempting to acquire the mutex..."
        mutex.WaitOne() |> ignore
        printfn "Mutex acquired, performing work..."
        Thread.Sleep(2000)  // эмуляция работы
    finally
        printfn "Releasing the mutex..."
        mutex.ReleaseMutex()

let thread1 = Thread(ThreadStart runWithMutex)
let thread2 = Thread(ThreadStart runWithMutex)

thread1.Start()
thread2.Start()
thread1.Join()
thread2.Join()

let monitorLock = obj()
let mutable conditionMet = false

let producer () =
    lock monitorLock (fun () ->
        printfn "Producer is producing item..."
        Thread.Sleep(1000)
        conditionMet <- true
        Monitor.Pulse(monitorLock)  // уведомление потребителя
        printfn "Producer has produced item.")

let consumer () =
    lock monitorLock (fun () ->
        while not conditionMet do
            printfn "Consumer is waiting..."
            Monitor.Wait(monitorLock)  // ожидание уведомления от производителя
        printfn "Consumer consumed the item.")

let producerThread = Thread(ThreadStart producer)
let consumerThread = Thread(ThreadStart consumer)

consumerThread.Start()
Thread.Sleep(500)  // задержка перед запуском производителя
producerThread.Start()

producerThread.Join()
consumerThread.Join()

let runWithSemaphore semaphore =
    printfn "Thread %d is waiting to enter..." Thread.CurrentThread.ManagedThreadId
    semaphore.WaitOne() |> ignore
    printfn "Thread %d entered!" Thread.CurrentThread.ManagedThreadId
    Thread.Sleep(1000)
    printfn "Thread %d is leaving..." Thread.CurrentThread.ManagedThreadId
    semaphore.Release() |> ignore

let semaphore = new Semaphore(2, 2)  // максимум два потока могут одновременно работать
let threads = [for _ in 1..5 -> Thread(ThreadStart(fun () -> runWithSemaphore semaphore))]

threads |> List.iter (fun t -> t.Start())
threads |> List.iter (fun t -> t.Join())

let asyncTask (token: CancellationToken) =
    async {
        for i in 1..10 do
            if token.IsCancellationRequested then
                printfn "Task was cancelled."
                return
            printfn "Working on step %d..." i
            do! Async.Sleep(500)
        printfn "Task completed."
    }

let cts = new CancellationTokenSource()

// Запуск задачи с возможностью отмены
Async.Start(asyncTask cts.Token, cancellationToken = cts.Token)
Thread.Sleep(1500)  // небольшая задержка
cts.Cancel()  // отмена задачи