import BaseRequestModel from "../base-request.model";

export default interface MyObjectRequestModel extends BaseRequestModel {
    code: number;
    value: string;
}
