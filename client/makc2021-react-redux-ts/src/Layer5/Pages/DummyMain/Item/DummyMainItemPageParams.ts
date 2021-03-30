/**
 * Параметры страницы сущности "DummyMain".
 */
export interface DummyMainItemPageParams {
  /**
   * Идентификатор.
   */
  id: string;
}

/**
 * Создать параметры страницы сущности "DummyMain".
 * @returns Параметры страницы сущности "DummyMain".
 */
export function createDummyMainItemPageParams(): DummyMainItemPageParams {
  return {
    id: ''
  } as DummyMainItemPageParams;
}
