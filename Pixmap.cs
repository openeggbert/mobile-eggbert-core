﻿// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Pixmap
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WindowsPhoneSpeedyBlupi;
using static System.Net.Mime.MediaTypeNames;
using static WindowsPhoneSpeedyBlupi.Def;
using static WindowsPhoneSpeedyBlupi.Xna;

namespace WindowsPhoneSpeedyBlupi
{
    public class Pixmap
    {
        private readonly Game1 game1;

        private readonly GraphicsDeviceManager graphics;

        private double zoom;

        private double originX;

        private double originY;

        private double hotSpotZoom;

        private double hotSpotX;

        private double hotSpotY;

        private SpriteBatch spriteBatch;

        private Texture2D bitmapText;

        private Texture2D bitmapButton;

        private Texture2D bitmapJauge;

        private Texture2D bitmapBlupi;

        private Texture2D bitmapBlupi1;

        private Texture2D bitmapObject;

        private Texture2D bitmapElement;

        private Texture2D bitmapExplo;

        private Texture2D bitmapPad;

        private Texture2D bitmapSpeedyBlupi;

        private Texture2D bitmapBlupiYoupie;

        private Texture2D bitmapGear;

        private Texture2D bitmapBackground;

        private Vector2 origin;

        private SpriteEffects effect;

        public TinyRect DrawBounds
        {
            get
            {
                TinyRect result = default(TinyRect);
                double screenWidth = graphics.GraphicsDevice.Viewport.Width;
                double screenHeight = graphics.GraphicsDevice.Viewport.Height;
                if(Env.PLATFORM == Platform.Android && screenHeight > 480) {
                    screenWidth = screenHeight * (640f / 480f);
                }
                if (screenWidth != 0.0 && screenHeight != 0.0)
                {
                    double num3;
                    double num4;
                    if (screenWidth / screenHeight < 1.3333333333333333)
                    {
                        num3 = 640.0;
                        num4 = 640.0 * (screenHeight / screenWidth);
                    }
                    else
                    {
                        num3 = 480.0 * (screenWidth / screenHeight);
                        num4 = 480.0;
                    }
                    result.LeftX = 0;
                    result.RightX = (int)num3;
                    result.TopY = 0;
                    result.BottomY = (int)num4;
                }
                return result;
            }
        }

        public TinyPoint Origin
        {
            get
            {
                TinyPoint result = default(TinyPoint);
                result.X = (int)originX;
                result.Y = (int)originY;
                return result;
            }
        }

        public Pixmap(Game1 game1, GraphicsDeviceManager graphics)
        {
            this.game1 = game1;
            this.graphics = graphics;
            origin = new Vector2(0f, 0f);
            effect = SpriteEffects.None;
        }

        public TinyPoint HotSpotToHud(TinyPoint pos)
        {
            TinyPoint result = default(TinyPoint);
            result.X = (int)((double)(pos.X - (int)hotSpotX) / hotSpotZoom) + (int)hotSpotX - (int)originX;
            result.Y = (int)((double)(pos.Y - (int)hotSpotY) / hotSpotZoom) + (int)hotSpotY - (int)originY;
            return result;
        }

        public void SetHotSpot(double zoom, double x, double y)
        {
            hotSpotZoom = zoom;
            hotSpotX = x;
            hotSpotY = y;
        }

        public void DrawInputButton(TinyRect rect, Def.ButtonGlyph glyph, bool pressed, bool selected)
        {
            switch (glyph)
            {
                case Def.ButtonGlyph.InitGamerA:
                    DrawIcon(14, selected ? 16 : 4, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.InitGamerB:
                    DrawIcon(14, selected ? 17 : 5, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.InitGamerC:
                    DrawIcon(14, selected ? 18 : 6, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.InitSetup:
                case Def.ButtonGlyph.PauseSetup:
                    DrawIcon(14, 19, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.InitPlay:
                    DrawIcon(14, 7, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.PauseMenu:
                case Def.ButtonGlyph.ResumeMenu:
                    DrawIcon(14, 11, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.PauseBack:
                    DrawIcon(14, 8, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.PauseRestart:
                    DrawIcon(14, 9, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.PauseContinue:
                case Def.ButtonGlyph.ResumeContinue:
                    DrawIcon(14, 10, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.WinLostReturn:
                    DrawIcon(14, 3, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.InitBuy:
                case Def.ButtonGlyph.TrialBuy:
                    DrawIcon(14, 22, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.InitRanking:
                    DrawIcon(14, 12, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.TrialCancel:
                case Def.ButtonGlyph.RankingContinue:
                    DrawIcon(14, 8, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.SetupSounds:
                case Def.ButtonGlyph.SetupJump:
                case Def.ButtonGlyph.SetupZoom:
                case Def.ButtonGlyph.SetupAccel:
                    DrawIcon(14, selected ? 13 : 21, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.SetupReset:
                    DrawIcon(14, 20, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.SetupReturn:
                    DrawIcon(14, 8, rect, pressed ? 0.8 : 1.0, false);
                    break;
                case Def.ButtonGlyph.PlayJump:
                    DrawIcon(14, 2, rect, pressed ? 0.6 : 1.0, false);
                    break;
                case Def.ButtonGlyph.PlayAction:
                    DrawIcon(14, 12, rect, pressed ? 0.6 : 1.0, false);
                    break;
                case Def.ButtonGlyph.PlayDown:
                    DrawIcon(14, 23, rect, pressed ? 0.6 : 1.0, false);
                    break;
                case Def.ButtonGlyph.PlayPause:
                    DrawIcon(14, 3, rect, pressed ? 0.6 : 1.0, false);
                    break;
                case Def.ButtonGlyph.Cheat1:
                case Def.ButtonGlyph.Cheat2:
                case Def.ButtonGlyph.Cheat3:
                case Def.ButtonGlyph.Cheat4:
                case Def.ButtonGlyph.Cheat5:
                case Def.ButtonGlyph.Cheat6:
                case Def.ButtonGlyph.Cheat7:
                case Def.ButtonGlyph.Cheat8:
                case Def.ButtonGlyph.Cheat9:
                    {
                        DrawIcon(14, 0, rect, pressed ? 0.6 : 1.0, false);
                        TinyPoint tinyPoint = default(TinyPoint);
                        tinyPoint.X = rect.LeftX + rect.Width / 2 - (int)originX;
                        tinyPoint.Y = rect.TopY + 28;
                        TinyPoint pos = tinyPoint;
                        Text.DrawTextCenter(this, pos, Decor.GetCheatTinyText(glyph), 1.0);
                        break;
                    }
                case Def.ButtonGlyph.Cheat11:
                case Def.ButtonGlyph.Cheat12:
                case Def.ButtonGlyph.Cheat21:
                case Def.ButtonGlyph.Cheat22:
                case Def.ButtonGlyph.Cheat31:
                case Def.ButtonGlyph.Cheat32:
                    break;
            }
        }

        public void LoadContent()
        {
            spriteBatch = new SpriteBatch(game1.GraphicsDevice);
            bitmapText = game1.Content.Load<Texture2D>("icons/text");
            bitmapButton = game1.Content.Load<Texture2D>("icons/button");
            bitmapJauge = game1.Content.Load<Texture2D>("icons/jauge");
            bitmapBlupi = game1.Content.Load<Texture2D>("icons/blupi");
            bitmapBlupi1 = game1.Content.Load<Texture2D>("icons/blupi1");
            bitmapObject = game1.Content.Load<Texture2D>("icons/object-m");
            bitmapElement = game1.Content.Load<Texture2D>("icons/element");
            bitmapExplo = game1.Content.Load<Texture2D>("icons/explo");
            bitmapPad = game1.Content.Load<Texture2D>("icons/pad");
            bitmapSpeedyBlupi = game1.Content.Load<Texture2D>("backgrounds/speedyblupi");
            bitmapBlupiYoupie = game1.Content.Load<Texture2D>("backgrounds/blupiyoupie");
            bitmapGear = game1.Content.Load<Texture2D>("backgrounds/gear");
            UpdateGeometry();
        }

        private void UpdateGeometry()
        {
            double screenWidth = graphics.GraphicsDevice.Viewport.Width;
            double screenHeight = graphics.GraphicsDevice.Viewport.Height;
            if (Env.PLATFORM == Platform.Android && screenHeight > 480)
            {
                screenWidth = screenHeight * (640f / 480f);
            }
            double val = screenWidth / 640.0;
            double val2 = screenHeight / 480.0;
            zoom = Math.Min(val, val2);
            originX = (screenWidth - 640.0 * zoom) / 2.0;
            originY = (screenHeight - 480.0 * zoom) / 2.0;
        }

        public void BackgroundCache(string name)
        {
            bitmapBackground = game1.Content.Load<Texture2D>("backgrounds/" + name);
        }

        public bool Start()
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            return true;
        }

        public bool Finish()
        {
            return true;
        }

        public void DrawBackground()
        {
            double screenWidth = graphics.GraphicsDevice.Viewport.Width;
            double screenHeight = graphics.GraphicsDevice.Viewport.Height;
            if (Env.PLATFORM == Platform.Android && screenHeight > 480)
            {
                screenWidth = screenHeight * (640f / 480f);
            }
            Texture2D bitmap = GetBitmap(3);
            Rectangle srcRectangle = GetSrcRectangle(bitmap, 10, 10, 10, 10, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, (int)screenWidth, (int)screenHeight);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(bitmap, destinationRectangle, srcRectangle, Color.White);
            spriteBatch.End();
            TinyPoint tinyPoint = default(TinyPoint);
            tinyPoint.X = (int)originX;
            tinyPoint.Y = (int)originY;
            TinyPoint dest = tinyPoint;
            TinyRect tinyRect = default(TinyRect);
            tinyRect.LeftX = 0;
            tinyRect.TopY = 0;
            tinyRect.RightX = 640;
            tinyRect.BottomY = 480;
            TinyRect rect = tinyRect;
            DrawPart(3, dest, rect);
        }

        public void DrawChar(int rank, TinyPoint pos, double size)
        {
            pos.X = (int)((double)pos.X + originX);
            pos.Y = (int)((double)pos.Y + originY);
            TinyRect tinyRect = default(TinyRect);
            tinyRect.LeftX = pos.X;
            tinyRect.TopY = pos.Y;
            tinyRect.RightX = pos.X + (int)(32.0 * size);
            tinyRect.BottomY = pos.Y + (int)(32.0 * size);
            TinyRect rect = tinyRect;
            DrawIcon(6, rank, rect, 1.0, false);
        }

        public void HudIcon(int channel, int rank, TinyPoint pos)
        {
            pos.X = (int)((double)pos.X + originX);
            pos.Y = (int)((double)pos.Y + originY);
            TinyRect tinyRect = default(TinyRect);
            tinyRect.LeftX = pos.X;
            tinyRect.TopY = pos.Y;
            tinyRect.RightX = pos.X;
            tinyRect.BottomY = pos.Y;
            TinyRect rect = tinyRect;
            DrawIcon(channel, rank, rect, 1.0, false);
        }

        public void QuickIcon(int channel, int rank, TinyPoint pos)
        {
            TinyRect tinyRect = default(TinyRect);
            tinyRect.LeftX = pos.X;
            tinyRect.TopY = pos.Y;
            tinyRect.RightX = pos.X;
            tinyRect.BottomY = pos.Y;
            TinyRect rect = tinyRect;
            DrawIcon(channel, rank, rect, 1.0, true);
        }

        public void QuickIcon(int channel, int rank, TinyPoint pos, double opacity, double rotation)
        {
            TinyRect tinyRect = default(TinyRect);
            tinyRect.LeftX = pos.X;
            tinyRect.TopY = pos.Y;
            tinyRect.RightX = pos.X;
            tinyRect.BottomY = pos.Y;
            TinyRect rect = tinyRect;
            DrawIcon(channel, rank, rect, opacity, rotation, true);
        }

        public bool DrawPart(int channel, TinyPoint dest, TinyRect rect)
        {
            return DrawPart(channel, dest, rect, 1.0);
        }

        public bool DrawPart(int channel, TinyPoint dest, TinyRect rect, double zoom)
        {
            Texture2D bitmap = GetBitmap(channel);
            if (bitmap == null)
            {
                return false;
            }
            if (channel == 5)
            {
                dest.X = (int)((double)dest.X + originX);
                dest.Y = (int)((double)dest.Y + originY);
            }
            Rectangle value = new Rectangle(rect.LeftX, rect.TopY, rect.Width, rect.Height);
            Rectangle destinationRectangle = new Rectangle(dest.X, dest.Y, (int)((double)rect.Width * zoom), (int)((double)rect.Height * zoom));
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(bitmap, destinationRectangle, value, Color.White);
            spriteBatch.End();
            return true;
        }

        public void DrawIcon(int channel, int icon, TinyRect rect, double opacity, bool useHotSpot)
        {
            DrawIcon(channel, icon, rect, opacity, 0.0, useHotSpot);
        }

        public void DrawIcon(int channel, int icon, TinyRect rect, double opacity, double rotation, bool useHotSpot)
        {
            if (icon == -1)
            {
                return;
            }
            Texture2D bitmap = GetBitmap(channel);
            if (bitmap == null)
            {
                return;
            }
            int num;
            int bitmapGridY;
            int iconWidth;
            int num2;
            int gap;
            switch (channel)
            {
                case 2:
                case 11:
                case 12:
                case 13:
                    num = 60;
                    bitmapGridY = 60;
                    iconWidth = 60;
                    num2 = 60;
                    gap = 0;
                    break;
                case 1:
                    num = 64;
                    bitmapGridY = 64;
                    iconWidth = 64;
                    num2 = 64;
                    gap = 1;
                    break;
                case 10:
                    num = 60;
                    bitmapGridY = 60;
                    iconWidth = 60;
                    num2 = 60;
                    gap = 0;
                    break;
                case 9:
                    num = 144;
                    bitmapGridY = 144;
                    num2 = Tables.table_explo_size[icon];
                    iconWidth = Math.Max(num2, 128);
                    gap = 0;
                    break;
                case 6:
                    num = 32;
                    bitmapGridY = 32;
                    iconWidth = 32;
                    num2 = 32;
                    gap = 0;
                    break;
                case 4:
                    num = 40;
                    bitmapGridY = 40;
                    iconWidth = 40;
                    num2 = 40;
                    gap = 0;
                    break;
                case 14:
                    num = 140;
                    bitmapGridY = 140;
                    iconWidth = 140;
                    num2 = 140;
                    gap = 0;
                    break;
                case 15:
                    num = 640;
                    bitmapGridY = 160;
                    iconWidth = 640;
                    num2 = 160;
                    gap = 0;
                    break;
                case 16:
                    num = 410;
                    bitmapGridY = 380;
                    iconWidth = 410;
                    num2 = 380;
                    gap = 0;
                    break;
                case 17:
                    num = 226;
                    bitmapGridY = 226;
                    iconWidth = 226;
                    num2 = 226;
                    gap = 0;
                    break;
                default:
                    num = 0;
                    bitmapGridY = 0;
                    iconWidth = 0;
                    num2 = 0;
                    gap = 0;
                    break;
            }
            if (num != 0)
            {
                Rectangle srcRectangle = GetSrcRectangle(bitmap, num, bitmapGridY, iconWidth, num2, gap, icon);
                Rectangle rectangle = GetDstRectangle(rect, iconWidth, num2, useHotSpot);
                float num3 = 0f;
                if (rotation != 0.0)
                {
                    num3 = (float)Misc.DegToRad(rotation);
                    rectangle = Misc.RotateAdjust(rectangle, num3);
                }
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spriteBatch.Draw(bitmap, rectangle, srcRectangle, Color.FromNonPremultiplied(255, 255, 255, (int)(255.0 * opacity)), num3, origin, effect, 0f);
                spriteBatch.End();
            }
        }

        private Rectangle GetSrcRectangle(Texture2D bitmap, int bitmapGridX, int bitmapGridY, int iconWidth, int iconHeight, int gap, int icon)
        {
            int width = bitmap.Bounds.Width;
            int height = bitmap.Bounds.Height;
            int num = icon % (width / bitmapGridX);
            int num2 = icon / (width / bitmapGridX);
            bitmapGridX += gap;
            bitmapGridY += gap;
            return new Rectangle(gap + num * bitmapGridX, gap + num2 * bitmapGridY, iconWidth, iconHeight);
        }

        private Rectangle GetDstRectangle(TinyRect rect, int iconWidth, int iconHeight, bool useHotSpot)
        {
            int num = ((rect.Width == 0) ? iconWidth : rect.Width);
            int num2 = ((rect.Height == 0) ? iconHeight : rect.Height);
            int num3 = (int)((double)rect.LeftX * zoom);
            int num4 = (int)((double)rect.TopY * zoom);
            int num5 = (int)((double)num3 + (double)num * zoom);
            int num6 = (int)((double)num4 + (double)num2 * zoom);
            if (useHotSpot && hotSpotZoom > 1.0)
            {
                num3 -= (int)hotSpotX;
                num4 -= (int)hotSpotY;
                num5 -= (int)hotSpotX;
                num6 -= (int)hotSpotY;
                num3 = (int)((double)num3 * hotSpotZoom);
                num4 = (int)((double)num4 * hotSpotZoom);
                num5 = (int)((double)num5 * hotSpotZoom);
                num6 = (int)((double)num6 * hotSpotZoom);
                num3 += (int)hotSpotX;
                num4 += (int)hotSpotY;
                num5 += (int)hotSpotX;
                num6 += (int)hotSpotY;
            }
            return new Rectangle(num3, num4, num5 - num3, num6 - num4);
        }

        private Texture2D GetBitmap(int channel)
        {
            switch (channel)
            {
                case 2:
                    return bitmapBlupi;
                case 11:
                case 12:
                case 13:
                    return bitmapBlupi1;
                case 1:
                    return bitmapObject;
                case 10:
                    return bitmapElement;
                case 9:
                    return bitmapExplo;
                case 6:
                    return bitmapText;
                case 4:
                    return bitmapButton;
                case 5:
                    return bitmapJauge;
                case 14:
                    return bitmapPad;
                case 15:
                    return bitmapSpeedyBlupi;
                case 16:
                    return bitmapBlupiYoupie;
                case 17:
                    return bitmapGear;
                case 3:
                    return bitmapBackground;
                default:
                    return null;
            }
        }
    }

}