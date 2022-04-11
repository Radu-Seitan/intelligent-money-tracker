import {Base} from "./Base.model";

export interface Store extends Base {
  name: string
  imageId?: string;
  appImage: string;
}
