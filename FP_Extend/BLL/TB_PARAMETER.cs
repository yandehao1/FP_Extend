﻿using System;
using System.Data;
using System.Collections.Generic;
using RURO.Common;
using RURO.Model;
using RURO.DALFactory;
using RURO.IDAL;
namespace RURO.BLL
{
	/// <summary>
	/// TB_PARAMETER
	/// </summary>
	public partial class TB_PARAMETER
	{
		private readonly ITB_PARAMETER dal=DataAccess.CreateTB_PARAMETER();
		public TB_PARAMETER()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PID)
		{
			return dal.Exists(PID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(RURO.Model.TB_PARAMETER model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RURO.Model.TB_PARAMETER model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PID)
		{
			
			return dal.Delete(PID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PIDlist )
		{
			return dal.DeleteList(RURO.Common.PageValidate.SafeLongFilter(PIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RURO.Model.TB_PARAMETER GetModel(int PID)
		{
			
			return dal.GetModel(PID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public RURO.Model.TB_PARAMETER GetModelByCache(int PID)
		{
			
			string CacheKey = "TB_PARAMETERModel-" + PID;
			object objModel = RURO.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PID);
					if (objModel != null)
					{
						int ModelCache = RURO.Common.ConfigHelper.GetConfigInt("ModelCache");
						RURO.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (RURO.Model.TB_PARAMETER)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RURO.Model.TB_PARAMETER> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RURO.Model.TB_PARAMETER> DataTableToList(DataTable dt)
		{
			List<RURO.Model.TB_PARAMETER> modelList = new List<RURO.Model.TB_PARAMETER>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RURO.Model.TB_PARAMETER model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

