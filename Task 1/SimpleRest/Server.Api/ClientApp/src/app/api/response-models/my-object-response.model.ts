import BaseResponseModel from "../base-response.model";

export default interface MyObjectResponseModel extends BaseResponseModel {
    code: number;
    value: string;
}
