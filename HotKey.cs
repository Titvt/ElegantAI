using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Avalonia.Input;
using Avalonia.Win32.Input;

namespace ElegantAI;

public static class HotKey
{
    private static readonly Native.WndProcDelegate LpfnWndProc = WndProc;
    private static readonly IntPtr HWnd;
    private static readonly Dictionary<int, Action> HotKeys = new();

    static HotKey()
    {
        var wndClass = new Native.WndClassExW
        {
            cbSize = (uint)Marshal.SizeOf<Native.WndClassExW>(),
            lpfnWndProc = LpfnWndProc,
            hInstance = Native.GetModuleHandleW(null),
            lpszClassName = Guid.NewGuid().ToString()
        };
        var className = Native.RegisterClassExW(wndClass);
        HWnd = Native.CreateWindowExW(0, className, null, 0, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
    }

    public static void Register(Key key, KeyModifiers keyModifiers, Action action)
    {
        var virtualKey = KeyInterop.VirtualKeyFromKey(key);
        var id = virtualKey + ((int)keyModifiers << 16);

        if (HotKeys.ContainsKey(id))
        {
            Unregister(key, keyModifiers);
        }

        Native.RegisterHotKey(HWnd, id, (uint)keyModifiers, (uint)virtualKey);
        HotKeys.Add(id, action);
    }

    public static void Unregister(Key key, KeyModifiers keyModifiers)
    {
        var virtualKey = KeyInterop.VirtualKeyFromKey(key);
        var id = virtualKey + ((int)keyModifiers << 16);
        Native.UnregisterHotKey(HWnd, id);
        HotKeys.Remove(id);
    }

    private static int WndProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam)
    {
        if (uMsg == 0x0312 && HotKeys.TryGetValue(wParam.ToInt32(), out var action))
        {
            action();
        }

        return Native.DefWindowProcW(hWnd, uMsg, wParam, lParam);
    }
}