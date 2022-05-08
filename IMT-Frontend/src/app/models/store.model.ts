import {Base} from "./base.model";

export interface Store extends Base {
  name: string
  imageId?: string;
  appImage: string;
}
