using System;
using System.Collections.Generic;

namespace Crass.Plugin.ARCGameEngine
{
    public class Util
    {
        public static byte[] LzssUncompress(byte[] compr, int length)
        {
            var uncompr = new byte[length];

            var comprlen = compr.Length;
            UInt32 act_uncomprlen = 0;
            /* compr中的当前扫描字节 */
            UInt32 curbyte = 0;
            UInt32 nCurWindowByte = 0xfee;
            UInt32 win_size = 4096;
            var win = new byte[4096];
            int flag = 0;

            win.MemSet((byte)0, (int)nCurWindowByte);
            while (true)
            {
                flag >>= 1;
                if ((flag & 0x0100) == 0)
                {
                    if (curbyte >= comprlen)
                        break;
                    flag = compr[curbyte++] | 0xff00;
                }

                if ((flag & 1) != 0)
                {
                    byte data;

                    if (curbyte >= comprlen)
                        break;

                    data = compr[curbyte++];
                    uncompr[act_uncomprlen++] = data;
                    /* 输出的1字节放入滑动窗口 */
                    win[nCurWindowByte++] = data;
                    nCurWindowByte &= win_size - 1;
                }
                else
                {
                    UInt32 copy_bytes, win_offset;
                    UInt32 i;

                    if (curbyte >= comprlen)
                        break;
                    win_offset = compr[curbyte++];

                    if (curbyte >= comprlen)
                        break;
                    copy_bytes = compr[curbyte++];
                    win_offset |= (copy_bytes & 0xf0) << 4;
                    copy_bytes &= 0x0f;
                    copy_bytes += 3;

                    for (i = 0; i < copy_bytes; i++)
                    {
                        byte data;

                        data = win[(win_offset + i) & (win_size - 1)];
                        uncompr[act_uncomprlen++] = data;
                        /* 输出的1字节放入滑动窗口 */
                        win[nCurWindowByte++] = data;
                        nCurWindowByte &= win_size - 1;
                    }
                }

            }
            return uncompr;
        }
    }
}
