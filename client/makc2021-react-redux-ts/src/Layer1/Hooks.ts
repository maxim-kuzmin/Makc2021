// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context } from './Context';

/**
 * Использовать сервис HTTP слоя "Layer1".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer1HttpService(context: Context) {
  return context.getModule().httpService;
}

/**
 * Использовать язык локализации слоя "Layer1".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer1LocalizationLanguage(context: Context) {
  return context.getModule().localizationLanguage;
}

/**
 * Использовать сервис локализации слоя "Layer1".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer1LocalizationService(context: Context) {
  return context.getModule().createLocalizationService;
}

/**
 * Использовать фабрику согласования слоя "Layer1".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer1TimingFactory(context: Context) {
  return context.getModule().timingFactory;
}

/**
 * Использовать сервис URL слоя "Layer1".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer1UrlService(context: Context) {
  return context.getModule().urlService;
}
