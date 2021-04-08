// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.
class HttpClient {
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
}

/**
 * Клиент HTTP.
 */
export const httpClient = new HttpClient();
