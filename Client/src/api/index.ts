import IConfig from './iconfig';
import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import config from './config-local';

@inject(config)
export default class Api extends HttpClient {
  constructor(private config: IConfig) {
    super();
    this.configure(c => {
      c.withBaseUrl(config.url);
    });
  }

  get(resourceUri) {
    return this.fetch(resourceUri)
      .then(res => res.json());
  }
}
