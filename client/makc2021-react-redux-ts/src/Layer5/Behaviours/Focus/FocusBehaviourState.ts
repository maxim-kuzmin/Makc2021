// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

/**
 * Состояние поведения фокуса.
 */
export interface FocusBehaviourState {
  /**
   * Идентификатор.
   */
  id: string;
}

/**
 * Создать состояние поведения фокуса.
 * @returns Состояние поведения фокуса.
 */
export function createFocusBehaviourState() {
  return {
    id: ''
  } as FocusBehaviourState;
}
