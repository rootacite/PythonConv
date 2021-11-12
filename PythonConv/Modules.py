from ctypes import *

lib = CDLL("PythonConv.dll");

def SetText(X):
    
    lib.SetText(c_wchar_p(X));