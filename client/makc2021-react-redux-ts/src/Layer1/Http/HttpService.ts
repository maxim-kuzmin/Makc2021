/**
 * Сервис HTTP.
 */
export class HttpService {
  /**
   * Запрос методом DELETE.
   * @template TResult Тип результата.
   * @param url URL.
   * @param customConfig Настраиваемая конфигурация.
   * @returns Обещание результата.
   */
  delete<TResult>(url: string, customConfig: any = {}): Promise<TResult> {
    return this.request<TResult>(url, {
      ...customConfig,
      method: 'DELETE'
    });
  }

  /**
   * Запрос методом GET.
   * @template TResult Тип результата.
   * @param url URL.
   * @param customConfig Настраиваемая конфигурация.
   * @returns Обещание результата.
   */
  get<TResult>(url: string, customConfig: any = {}): Promise<TResult> {
    return this.request<TResult>(url, {
      ...customConfig,
      method: 'GET'
    });
  }

  /**
   * Запрос методом POST.
   * @template TResult Тип результата.
   * @param url URL.
   * @param body Тело.
   * @param customConfig Настраиваемая конфигурация.
   * @returns Обещание результата.
   */
  post<TResult>(
    url: string,
    body: any,
    customConfig: any = {}
  ): Promise<TResult> {
    return this.request<TResult>(url, {
      ...customConfig,
      method: 'POST',
      body
    });
  }

  /**
   * Запрос методом PUT.
   * @template TResult Тип результата.
   * @param url URL.
   * @param body Тело.
   * @param customConfig Настраиваемая конфигурация.
   * @returns Обещание результата.
   */
  put<TResult>(
    url: string,
    body: any,
    customConfig: any = {}
  ): Promise<TResult> {
    return this.request<TResult>(url, {
      ...customConfig,
      method: 'PUT',
      body
    });
  }

  async request<TResult>(url: string, payload: any = {}): Promise<TResult> {
    const { body, ...customConfig } = payload;

    const headers = { 'Content-Type': 'application/json' };

    const config = {
      credentials: 'include',
      mode: 'cors',
      ...customConfig,
      headers: {
        ...headers,
        ...customConfig.headers
      }
    } as RequestInit;

    if (body) {
      config.body = JSON.stringify(body);
    }

    const response = await window.fetch(url, config);

    if (!response.ok) {
      throw new Error(response.statusText);
    }

    return (await response.json()) as TResult;
  }
}
