import { Lazy } from 'src/Layer1/Lazy';
import { Context as InfrastructureLayerContext } from 'src/Layer1/Context';
import { ControlsContext } from './Controls/ControlsContext';
import { PagesContext } from './Pages/PagesContext';
import { Service } from './Service';
import { Module } from './Module';
import { BehavioursContext } from './Behaviours/BehavioursContext';

/**
 * Контекст.
 */
export class Context {
  private _module = new Module();

  /**
   * Поведения.
   */
  readonly Behaviours = new BehavioursContext();

  /**
   * Элементы управления.
   */
  readonly Controls = new ControlsContext();

  /**
   * Страницы.
   */
  readonly Pages = new PagesContext();

  /**
   * Настроить сервисы.
   * @param contextOfInfrastructureLayer Контекст слоя "InfrastructureLayer".
   * @param apiUrl URL API.
   */
  configureServices(
    contextOfInfrastructureLayer: InfrastructureLayerContext,
    apiUrl: string
  ) {
    const instanceOfService = new Lazy<Service>(() => new Service(apiUrl));

    this._module.serviceGetter = () => {
      return instanceOfService.value;
    };

    this.Behaviours.configureServices();

    this.Controls.configureServices();

    this.Pages.configureServices(this, contextOfInfrastructureLayer);
  }

  /**
   * Получить модуль.
   * @returns Модуль.
   */
  getModule() {
    return this._module;
  }
}
